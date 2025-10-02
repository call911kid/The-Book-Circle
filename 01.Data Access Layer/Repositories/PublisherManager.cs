using Microsoft.EntityFrameworkCore;
using The_Book_Circle.Context;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;

namespace The_Book_Circle.Repositories
{
    public class PublisherManager : GenericManager<Publisher>, IPublisherRepository
    {
        private readonly BooksContext _context;
        public PublisherManager(BooksContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Publisher?> GetByNameAsync(string publisherName)
        {
            return await _context.Publishers
                .FirstOrDefaultAsync(p => p.Name == publisherName);


        }
    }
}
