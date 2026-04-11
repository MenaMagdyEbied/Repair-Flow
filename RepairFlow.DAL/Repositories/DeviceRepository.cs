using Microsoft.EntityFrameworkCore;
using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }

        public List<Device> GetAllWithCustomer()
        {
            return _context.Devices
                .Include(d => d.Customer)
                .Include(d => d.DeviceSpareParts)
                    .ThenInclude(dsp => dsp.SparePart)
                .OrderByDescending(d => d.ReceivedAt)
                .ToList();
        }

        public Device? GetByReceipt(string receiptNumber)
        {
            return _context.Devices
                .Include(d => d.Customer)
                .Include(d => d.DeviceSpareParts)
                    .ThenInclude(dsp => dsp.SparePart)
                .FirstOrDefault(d => d.ReceiptNumber == receiptNumber);
        }

        public int CountByStatus(RepairStatus status)
        {
            return _context.Devices.Count(d => d.Status == status);
        }

        public int CountAll()
        {
            return _context.Devices.Count();
        }

        public string? GetLastReceiptNumber()
        {
            return _context.Devices
                .OrderByDescending(d => d.Id)
                .Select(d => d.ReceiptNumber)
                .FirstOrDefault();
        }
    }
}
