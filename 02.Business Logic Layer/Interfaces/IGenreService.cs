using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle.Services.Interfaces
{
    public interface IGenreService
    {
        Task<ServiceResult<IEnumerable<GenreDto>>> GetAllGenresAsync();
        Task<ServiceResult<GenreDto>> GetGenreByIdAsync(int ID);
        Task <ServiceResult<GenreDto>> CreateGenreAsync(CreateGenreDto createGenreDto);
    }
}
