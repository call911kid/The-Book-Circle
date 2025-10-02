using The_Book_Circle.Models;

namespace The_Book_Circle.Repositories.Interfaces
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<Publisher?> GetByNameAsync(string publisherName);
    }
}
