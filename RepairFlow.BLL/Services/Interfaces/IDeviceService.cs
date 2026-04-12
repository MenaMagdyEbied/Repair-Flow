using RepairFlow.Models;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface IDeviceService
    {
        List<Device> GetAllDevices();
        Device? GetDeviceByReceipt(string receiptNumber);
        void UpdateStatus(string receiptNumber, string statusArabic);
        void UpdateDeviceDetails(Device device);
        Dictionary<string, string> GetStatusCounts();
        void AddSparePart(string receiptNumber, string partName, int quantity, decimal price);
        void RemoveSparePart(string receiptNumber, int deviceSparePartId);

        // Simple add (auto-generates receipt number)
        Device AddDevice(string customerName, string customerPhone, string deviceName, string model, string fault, string accessories);

        // Full add with validation (used by ReciptForm)
        Device AddDevice(string receiptNumber, string customerName, string customerPhone,
                         string deviceName, string model, string fault, string accessories,
                         decimal? repairCost, string warrantyText, string statusText, DateTime receivedAt);

        string GenerateReceiptNumber();
        void DeleteDevice(int deviceId);
    }
}
