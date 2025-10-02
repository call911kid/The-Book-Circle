using The_Book_Circle.Models;

namespace The_Book_Circle.Repositories.Interfaces
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {

        Task<Genre?> GetByNameAsync(string genreName);
    }
}
