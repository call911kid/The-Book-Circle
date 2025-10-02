using Microsoft.EntityFrameworkCore;
using The_Book_Circle.Context;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class BookManager : GenericManager<Book>, IBookRepository
    {
        private readonly BooksContext _context;
        public BookManager(BooksContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Book?> GetByISBNAsync(string bookISBN)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.ISBN == bookISBN);
        }
        public async Task<IEnumerable<Book>> SearchAsync(string query)
        {
            IQueryable<Book> books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Genres);

            books = books.Where(b =>
                EF.Functions.Like(b.Title, $"%{query}%") ||
                EF.Functions.Like(b.ISBN, $"%{query}%") ||
                EF.Functions.Like(b.Author.FullName, $"%{query}%") ||
                EF.Functions.Like(b.Publisher.Name, $"%{query}%") ||
                b.Genres.Any(g => EF.Functions.Like(g.Name, $"%{query}%"))
            );

            return await books.ToListAsync();

        }
        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorID)
        {
            return await _context.Books
                .Where(b => b.AuthorID == authorID)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenreAsync(int genreID)
        {
            return await _context.Books
                .Where(b => b.Genres.Any(g => g.ID == genreID))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherID)
        {
            return await _context.Books
                .Where(b => b.PublisherID == publisherID)
                .ToListAsync();
        }
    }

}
