using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Customer? GetByPhone(string phone);
        void Add(Customer customer);
        void Update(Customer customer);
    }
}
