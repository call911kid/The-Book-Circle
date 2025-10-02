using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<ServiceResult<IEnumerable<AuthorDto>>> GetAllAuthorsAsync();
        Task<ServiceResult<AuthorDto>> GetAuthorByIdAsync(int ID);
        Task<ServiceResult<AuthorDto>> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
    }
}
