using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public class SparePartRepository : BaseRepository<SparePart>, ISparePartRepository
    {
        public SparePartRepository(AppDbContext context) : base(context)
        {
        }

        public List<SparePart> GetAll()
        {
            return _context.SpareParts.OrderBy(p => p.Name).ToList();
        }

        public SparePart? GetByName(string name)
        {
            return _context.SpareParts.FirstOrDefault(p => p.Name == name);
        }

        public SparePart? GetByCode(string code)
        {
            return _context.SpareParts.FirstOrDefault(p => p.Code == code);
        }
    }
}
