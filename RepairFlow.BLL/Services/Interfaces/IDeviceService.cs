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

        Device AddDevice(string customerName, string customerPhone, string deviceName, string model, string fault, string accessories);
        string GenerateReceiptNumber();
        void DeleteDevice(int deviceId);
    }
}
