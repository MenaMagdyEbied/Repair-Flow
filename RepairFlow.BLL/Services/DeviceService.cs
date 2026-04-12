using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;

namespace RepairFlow.BLL.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;
        private readonly ISparePartRepository _partRepo;
        private readonly ICustomerRepository _customerRepo;

        public DeviceService(
            IDeviceRepository deviceRepo,
            ISparePartRepository partRepo,
            ICustomerRepository customerRepo)
        {
            _deviceRepo = deviceRepo;
            _partRepo = partRepo;
            _customerRepo = customerRepo;
        }

        public List<Device> GetAllDevices() => _deviceRepo.GetAllWithCustomer();

        public Device? GetDeviceByReceipt(string receiptNumber) => _deviceRepo.GetByReceipt(receiptNumber);

        public void UpdateStatus(string receiptNumber, string statusArabic)
        {
            var device = _deviceRepo.GetByReceipt(receiptNumber);
            if (device == null) return;

            var newStatus = MapArabicToStatus(statusArabic);
            if (device.Status == newStatus) return;

            var oldStatus = device.Status;

            if (newStatus == RepairStatus.Delivered && oldStatus != RepairStatus.Delivered)
            {
                device.DeliveredAt = DateTime.Now;
            }
            else if (newStatus != RepairStatus.Delivered)
            {
                device.DeliveredAt = null;
            }

            device.Status = newStatus;

            device.StatusHistories.Add(new StatusHistory
            {
                DeviceId = device.Id,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                ChangedAt = DateTime.Now,
                Note = $"تم تغيير الحالة إلى: {statusArabic}"
            });

            _deviceRepo.Update(device);
        }

        public void UpdateDeviceDetails(Device device) => _deviceRepo.Update(device);

        public Dictionary<string, string> GetStatusCounts()
        {
            return new Dictionary<string, string>
            {
                { "الكل",          _deviceRepo.CountAll().ToString() },
                { "وارد جديد",    _deviceRepo.CountByStatus(RepairStatus.NewArrival).ToString() },
                { "قيد الفحص",    _deviceRepo.CountByStatus(RepairStatus.UnderInspection).ToString() },
                { "تحت الإصلاح",  _deviceRepo.CountByStatus(RepairStatus.UnderRepair).ToString() },
                { "جاهز",          _deviceRepo.CountByStatus(RepairStatus.Ready).ToString() },
                { "تم التسليم",   _deviceRepo.CountByStatus(RepairStatus.Delivered).ToString() }
            };
        }

        // ── Simple overload (auto-generates receipt number) ──────────────────
        public Device AddDevice(string customerName, string customerPhone,
                                string deviceName, string model,
                                string fault, string accessories)
        {
            var customer = _customerRepo.GetByPhone(customerPhone)
                           ?? new Customer { Name = customerName, Phone = customerPhone };

            if (customer.Id == 0) _customerRepo.Add(customer);

            var device = new Device
            {
                CustomerId    = customer.Id,
                DeviceName    = deviceName,
                Model         = model,
                Fault         = fault,
                Accessories   = accessories,
                ReceiptNumber = GenerateReceiptNumber(),
                Status        = RepairStatus.NewArrival,
                ReceivedAt    = DateTime.Now
            };

            device.StatusHistories.Add(new StatusHistory
            {
                OldStatus = RepairStatus.NewArrival,
                NewStatus = RepairStatus.NewArrival,
                ChangedAt = DateTime.Now,
                Note = "استلام الجهاز لأول مرة (وارد جديد)"
            });

            _deviceRepo.Add(device);
            return device;
        }

        // ── Full overload with validation (used by ReciptForm) ────────────────
        public Device AddDevice(string receiptNumber, string customerName, string customerPhone,
                                string deviceName, string model, string fault, string accessories,
                                decimal? repairCost, string warrantyText, string statusText,
                                DateTime receivedAt)
        {
            ValidateCustomerName(customerName);
            ValidatePhone(customerPhone);
            ValidateDevice(deviceName, model, fault);

            int warrantyMonths = ParseWarrantyMonths(warrantyText);
            RepairStatus status = ParseStatus(statusText);

            var customer = _customerRepo.GetByPhone(customerPhone);
            if (customer == null)
            {
                customer = new Customer { Name = customerName.Trim(), Phone = customerPhone };
                _customerRepo.Add(customer);
            }

            var device = new Device
            {
                ReceiptNumber  = receiptNumber,
                CustomerId     = customer.Id,
                DeviceName     = deviceName,
                Model          = model,
                Fault          = fault,
                Accessories    = accessories,
                RepairCost     = repairCost,
                Status         = status,
                ReceivedAt     = receivedAt,
                WarrantyMonths = warrantyMonths
            };

            device.StatusHistories.Add(new StatusHistory
            {
                OldStatus = status,
                NewStatus = status,
                ChangedAt = DateTime.Now,
                Note = "استلام الجهاز لأول مرة"
            });

            _deviceRepo.Add(device);
            return device;
        }

        public string GenerateReceiptNumber()
        {
            var year   = DateTime.Now.Year;
            var prefix = $"RF-{year}-";

            var lastReceipt = _deviceRepo.GetLastReceiptNumber();
            int nextNumber  = 1;

            if (!string.IsNullOrEmpty(lastReceipt) && lastReceipt.StartsWith(prefix))
            {
                var parts = lastReceipt.Split('-');
                if (parts.Length == 3 && int.TryParse(parts[2], out int lastNum))
                {
                    nextNumber = lastNum + 1;
                }
            }

            return $"{prefix}{nextNumber:D3}";
        }

        public void DeleteDevice(int deviceId)
        {
            var device = _deviceRepo.GetAllWithCustomer().FirstOrDefault(d => d.Id == deviceId);
            if (device != null)
            {
                _deviceRepo.Delete(device);
            }
        }

        public void AddSparePart(string receiptNumber, string partName, int quantity, decimal price)
        {
            var device = _deviceRepo.GetByReceipt(receiptNumber);
            if (device == null) return;

            var part = _partRepo.GetByName(partName);
            if (part == null) return;

            device.DeviceSpareParts.Add(new DeviceSparePart
            {
                DeviceId     = device.Id,
                SparePartId  = part.Id,
                QuantityUsed = quantity,
                UnitPrice    = price
            });

            device.RepairCost = device.DeviceSpareParts.Sum(p => p.QuantityUsed * p.UnitPrice);
            _deviceRepo.Update(device);
        }

        public void RemoveSparePart(string receiptNumber, int deviceSparePartId)
        {
            var device = _deviceRepo.GetByReceipt(receiptNumber);
            if (device == null) return;

            var partToRemove = device.DeviceSpareParts.FirstOrDefault(p => p.Id == deviceSparePartId);
            if (partToRemove != null)
            {
                device.DeviceSpareParts.Remove(partToRemove);
                device.RepairCost = device.DeviceSpareParts.Count > 0
                    ? device.DeviceSpareParts.Sum(p => p.QuantityUsed * p.UnitPrice)
                    : null;

                _deviceRepo.Update(device);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private static RepairStatus MapArabicToStatus(string arabic) => arabic switch
        {
            "وارد جديد"    => RepairStatus.NewArrival,
            "قيد الفحص"   => RepairStatus.UnderInspection,
            "تحت الإصلاح" => RepairStatus.UnderRepair,
            "جاهز"         => RepairStatus.Ready,
            "تم التسليم"  => RepairStatus.Delivered,
            _              => RepairStatus.NewArrival
        };

        private static void ValidateCustomerName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("يرجى إدخال اسم العميل.");
            var parts = name.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                throw new ArgumentException("اسم العميل يجب أن يحتوي على الاسم الأول والأخير مفصولين بمسافة.");
        }

        private static void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("يرجى إدخال رقم الهاتف.");
            if (!phone.StartsWith("01") || phone.Length != 11 || !phone.All(char.IsDigit))
                throw new ArgumentException("رقم الهاتف يجب أن يحتوي على 11 رقم فقط ولا يحتوي على رموز أو أحرف.");
        }

        private static void ValidateDevice(string brand, string model, string fault)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("يجب أن تختار نوع الجهاز.");
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("يجب كتابة اسم الموديل.");
            if (string.IsNullOrWhiteSpace(fault)) throw new ArgumentException("يجب كتابة ما هو العطل.");
        }

        private static int ParseWarrantyMonths(string text) => text switch
        {
            "ضمان 3 أشهر" => 3,
            "ضمان 6 أشهر" => 6,
            "ضمان سنة"    => 12,
            _             => 0
        };

        private static RepairStatus ParseStatus(string label) => label switch
        {
            "وارد جديد"     => RepairStatus.NewArrival,
            "قيد الفحص"    => RepairStatus.UnderInspection,
            "قيد الإصلاح"  => RepairStatus.UnderRepair,
            "تحت الإصلاح"  => RepairStatus.UnderRepair,
            "جاهز"          => RepairStatus.Ready,
            "جاهز للتسليم" => RepairStatus.Ready,
            "تم التسليم"   => RepairStatus.Delivered,
            _               => RepairStatus.NewArrival
        };
    }
}
