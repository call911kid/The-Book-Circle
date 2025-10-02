using The_Book_Circle.Models;

namespace The_Book_Circle.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetByISBNAsync(string bookISBN);
        Task<IEnumerable<Book>> SearchAsync(string query);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorID);
        Task<IEnumerable<Book>> GetBooksByGenreAsync(int genreID);
        Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherID);
    }
}
