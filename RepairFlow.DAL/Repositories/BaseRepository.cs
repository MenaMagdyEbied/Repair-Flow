using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RepairFlow.DAL.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private   readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet   = context.Set<T>();
        }

        public List<T> GetAll() => _dbSet.ToList();
        public T? GetById(int id) => _dbSet.Find(id);
        public List<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();

        public void Add(T entity) { _dbSet.Add(entity); _context.SaveChanges(); }
        public void Update(T entity) { _dbSet.Update(entity); _context.SaveChanges(); }
        public void Delete(T entity) { _dbSet.Remove(entity); _context.SaveChanges(); }
    }
}
