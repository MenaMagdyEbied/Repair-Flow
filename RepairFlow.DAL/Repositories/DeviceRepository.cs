using RepairFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace RepairFlow.DAL.Repositories
{
    public class DeviceRepository : BaseRepository<Device>
    {
        public DeviceRepository(AppDbContext context) : base(context) { }

        public void AddDeviceWithCustomer(Device device, string customerName, string phone)
        {
            // Find existing customer or create new one
            var customer = _context.Customers
                .FirstOrDefault(c => c.Name == customerName.Trim() && c.Phone == phone);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = customerName.Trim(),
                    Phone = phone
                };
                _context.Customers.Add(customer);
            }

            // Associate device with customer
            device.CustomerId = customer.Id;
            device.Customer = customer;

            // Add device
            Add(device);
        }

        public List<Device> GetAllWithCustomers()
        {
            return _context.Devices
                .Include(d => d.Customer)
                .OrderByDescending(d => d.ReceivedAt)
                .ToList();
        }

        public string GetNextReceiptNumber()
        {
            string datePart = DateTime.Now.ToString("yyMM");
            var existing = _context.Devices
                .Where(d => d.ReceiptNumber.StartsWith($"SR-{datePart}-"))
                .Select(d => d.ReceiptNumber)
                .ToList();

            int maxCounter = 0;
            foreach (var receipt in existing)
            {
                if (receipt.Length > 8 && int.TryParse(receipt.Substring(8), out int counter))
                {
                    maxCounter = Math.Max(maxCounter, counter);
                }
            }

            int nextCounter = maxCounter + 1;
            return $"SR-{datePart}-{nextCounter:D3}";
        }
    }
}