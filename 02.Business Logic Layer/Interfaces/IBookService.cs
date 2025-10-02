using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle.Services.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResult<IEnumerable<BookDto>>> GetAllBooksAsync();
        Task<ServiceResult<BookDto>> GetBookByISBN(string ISBN);
        Task<ServiceResult<BookDto>> GetBookByIdAsync(int iD);
        Task<ServiceResult<BookDto>> CreateBookAsync(CreateBookDto createBookDto);
        
        Task<ServiceResult<IEnumerable<BookDto>>> SearchBooksAsync(string query);
        //Task<BookDto?> UpdateBookAsync(int id, BookDto bookDto);
        //Task<bool> DeleteBookAsync(int iD);

        //Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorID);
        //Task<IEnumerable<BookDto>> GetBooksByPublisherAsync(int publisherID);
        //Task<IEnumerable<BookDto>> GetBooksByGenreAsync(int genreID);
    }
}
