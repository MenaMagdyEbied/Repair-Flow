using RepairFlow.Models;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface ISparePartService
    {
        List<SparePart> GetInventory();
        SparePart? GetPartByName(string name);
        List<SparePart> GetLowStock();
        SparePart? GetPartByCode(string code);
        void AddSparePart(SparePart part);
        void UpdateSparePart(SparePart part);
        void DeleteSparePart(int id);
        void DeductStock(int id, int qty);
        void AddStock(int id, int qty);
    }
}
