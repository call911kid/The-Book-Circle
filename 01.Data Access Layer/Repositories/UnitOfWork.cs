using Microsoft.EntityFrameworkCore.Storage;
using The_Book_Circle.Context;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksContext _context;

        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }
        public IGenreRepository Genres { get; }
        public IPublisherRepository Publishers { get; }

        public UnitOfWork(BooksContext context,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository,
            IPublisherRepository publisherRepository)
        {
            _context = context;
            Books = bookRepository;
            Authors = authorRepository;
            Genres = genreRepository;
            Publishers = publisherRepository;
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _context.Database.BeginTransactionAsync();

        public void Dispose() => _context.Dispose();



    }
}
