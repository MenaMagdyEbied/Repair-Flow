using RepairFlow.DAL.Repositories;
using RepairFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace RepairFlow.BLL
{
    public class DeviceService
    {
        private readonly DeviceRepository _deviceRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public void AddDeviceWithCustomer(Device device, string customerName, string phone)
        {
            _deviceRepository.AddDeviceWithCustomer(device, customerName, phone);
        }

        public List<Device> GetAllDevices()
        {
            return _deviceRepository.GetAllWithCustomers();
        }

        public string GetNextReceiptNumber()
        {
            return _deviceRepository.GetNextReceiptNumber();
        }

        // Validation methods (private)
        private void ValidateCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("يرجى إدخال اسم العميل.");

            string[] nameParts = customerName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length != 2 || string.IsNullOrWhiteSpace(nameParts[0]) || string.IsNullOrWhiteSpace(nameParts[1]))
                throw new ArgumentException("اسم العميل يجب أن يحتوي على الاسم الأول والأخير مفصولين بمسافة.");
        }

        private void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("يرجى إدخال رقم الهاتف.");

            if (!phone.StartsWith("01") || phone.Length != 11 || !phone.All(char.IsDigit))
                throw new ArgumentException("رقم الهاتف يجب ان يحتوي علي 11 رقم فقط ولا يحتوي علي اي رموز او احرف.");
        }

        private void ValidateDevice(string brand, string model, string fault)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("يجب ان تختار نوع الجهاز.");

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("تنبيه يجب كتابه اسم الموديل.");

            if (string.IsNullOrWhiteSpace(fault))
                throw new ArgumentException("يجب كتابه ما هو العطل.");
        }

        // Parsing methods
        public RepairStatus ParseStatus(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                return RepairStatus.NewArrival;

            return label switch
            {
                "وارد جديد" => RepairStatus.NewArrival,
                "قيد الفحص" => RepairStatus.UnderInspection,
                "قيد الإصلاح" => RepairStatus.UnderRepair,
                "جاهز" => RepairStatus.Ready,
                "جاهز للتسليم" => RepairStatus.Ready,
                "تم التسليم" => RepairStatus.Delivered,
                _ => RepairStatus.NewArrival
            };
        }

        public int ParseWarrantyMonths(string text) => text switch
        {
            "ضمان 3 أشهر" => 3,
            "ضمان 6 أشهر" => 6,
            "ضمان سنة" => 12,
            _ => 0
        };

        // Comprehensive method to add device with validation
        public Device AddDevice(string receiptNumber, string customerName, string phone, string brand, string model, string fault, string accessories, decimal? repairCost, string warrantyText, string statusText, DateTime receivedAt)
        {
            ValidateCustomerName(customerName);
            ValidatePhone(phone);
            ValidateDevice(brand, model, fault);

            int warrantyMonths = ParseWarrantyMonths(warrantyText);
            RepairStatus status = ParseStatus(statusText);

            var device = new Device
            {
                ReceiptNumber = receiptNumber,
                DeviceName = brand,
                Model = model,
                Fault = fault,
                Accessories = accessories,
                RepairCost = repairCost,
                PaidAmount = null,
                Status = status,
                ReceivedAt = receivedAt,
                WarrantyMonths = warrantyMonths
            };

            AddDeviceWithCustomer(device, customerName.Trim(), phone);
            return device;
        }
    }
}