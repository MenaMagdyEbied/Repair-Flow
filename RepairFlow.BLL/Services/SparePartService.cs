using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;

namespace RepairFlow.BLL.Services
{
    public class SparePartService : ISparePartService
    {
        private readonly ISparePartRepository _partRepo;

        public SparePartService(ISparePartRepository partRepo)
        {
            _partRepo = partRepo;
        }

        public List<SparePart> GetInventory() => _partRepo.GetAll();

        public SparePart? GetPartByName(string name) => _partRepo.GetByName(name);

        public List<SparePart> GetLowStock() => _partRepo.GetAll()
            .Where(p => p.Quantity < p.AlertThreshold).ToList();

        public SparePart? GetPartByCode(string code) => _partRepo.GetByCode(code);

        public void AddSparePart(SparePart part) => _partRepo.Add(part);

        public void UpdateSparePart(SparePart part) => _partRepo.Update(part);

        public void DeleteSparePart(int id)
        {
            var part = _partRepo.GetById(id);
            if (part != null) _partRepo.Delete(part);
        }

        public void DeductStock(int id, int qty)
        {
            var part = _partRepo.GetById(id);
            if (part != null)
            {
                part.Quantity -= qty;
                _partRepo.Update(part);
            }
        }

        public void AddStock(int id, int qty)
        {
            var part = _partRepo.GetById(id);
            if (part != null)
            {
                part.Quantity += qty;
                _partRepo.Update(part);
            }
        }
    }
}
