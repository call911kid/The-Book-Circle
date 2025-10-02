using Microsoft.EntityFrameworkCore;
using The_Book_Circle.Context;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class AuthorManager : GenericManager<Author>, IAuthorRepository
    {
        private readonly BooksContext _context;
        public AuthorManager(BooksContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Author?> GetByNameAsync(string authorName)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(a => a.FullName == authorName);
        }
        public async Task<IEnumerable<Author>> GetAuthorByBookAsync(int bookID)
        {
            return await _context.Authors
                .Where(a => a.Books.Any(b => b.ID == bookID))
                .ToListAsync();
        }
    }
}
