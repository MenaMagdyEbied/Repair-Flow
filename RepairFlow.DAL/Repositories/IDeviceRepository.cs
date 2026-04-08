using RepairFlow.Models;
using System.Linq.Expressions;

namespace RepairFlow.DAL.Repositories
{
    public interface IDeviceRepository
    {
        List<Device> GetAllWithCustomer();
        Device? GetByReceipt(string receiptNumber);
        void Add(Device device);
        void Update(Device device);
        void Delete(Device device);
        int CountByStatus(RepairStatus status);
        int CountAll();
        string? GetLastReceiptNumber();
    }
}
