using Microsoft.EntityFrameworkCore;
using RepairFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace RepairFlow.DAL.Repositories
{
    {
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

        {
            return _context.Devices
                .Include(d => d.Customer)
                .Include(d => d.DeviceSpareParts)
                    .ThenInclude(dsp => dsp.SparePart)
                .OrderByDescending(d => d.ReceivedAt)
                .ToList();
        }

        {

        {
        }

        public int CountAll()
        {
            return _context.Devices.Count();
        }

        }
    }
}
