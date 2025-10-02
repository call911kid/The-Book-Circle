using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<ServiceResult<IEnumerable<PublisherDto>>> GetAllPublishersAsync();
        Task<ServiceResult<PublisherDto>> GetPublisherByIdAsync(int ID);
        Task<ServiceResult<PublisherDto>> CreatePublisherAsync(CreatePublisherDto createPublisherDto);
    }
}
