using Microsoft.EntityFrameworkCore;
using The_Book_Circle.Context;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class GenreManager : GenericManager<Genre>, IGenreRepository
    {
        private readonly BooksContext _context;
        public GenreManager(BooksContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Genre?> GetByNameAsync(string genreName)
        {
            return await _context.Genres
                .FirstOrDefaultAsync(g => g.Name == genreName);

        }
    }
}
