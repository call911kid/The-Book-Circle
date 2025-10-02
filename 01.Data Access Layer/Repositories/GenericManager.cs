using Microsoft.EntityFrameworkCore;
using The_Book_Circle.Context;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class GenericManager<T> : IGenericRepository<T> where T : class
    {
        private readonly BooksContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericManager(BooksContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Update(T entity)
           => _dbSet.Update(entity);

        public void Delete(T entity)
            => _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
           => await _dbSet.FindAsync(id);

        public async Task SaveChangesAsync()
           => await _context.SaveChangesAsync();


    }
}
