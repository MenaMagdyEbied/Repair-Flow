using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public interface ISparePartRepository
    {
        List<SparePart> GetAll();
        SparePart? GetByName(string name);
        SparePart? GetByCode(string code);
        SparePart? GetById(int id);
        void Add(SparePart part);
        void Update(SparePart part);
        void Delete(SparePart part);

    }
}
