using The_Book_Circle.Models;

namespace The_Book_Circle.Repositories.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetByNameAsync(string authorName);
        Task<IEnumerable<Author>> GetAuthorByBookAsync(int bookID);

    }
}
