using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle._02.Business_Logic_Layer.Exceptions;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherManager;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherManager, IMapper mapper)
        {
            _publisherManager = publisherManager;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<PublisherDto>>> GetAllPublishersAsync()
        {
            var publishers = await _publisherManager.GetAllAsync();
            var publisherDtos = _mapper.Map<IEnumerable<PublisherDto>>(publishers);

            return ServiceResult<IEnumerable<PublisherDto>>
                .Success(publisherDtos);
        }
        public async Task<ServiceResult<PublisherDto>> GetPublisherByIdAsync(int ID)
        {
            var publisher = await _publisherManager.GetByIdAsync(ID)
                ?? throw new NotFoundException("Publisher not found.");
            
            var publisherDto = _mapper.Map<PublisherDto>(publisher);

            return ServiceResult<PublisherDto>
                .Success(publisherDto);
        }
        public async Task<ServiceResult<PublisherDto>> CreatePublisherAsync(CreatePublisherDto createPublisherDto)
        {
            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            await _publisherManager.CreateAsync(publisher);

            var createdPublisher = _mapper.Map<PublisherDto>(publisher);
            await _publisherManager.SaveChangesAsync();

            return ServiceResult<PublisherDto>
                .Success(createdPublisher);
        }

        
    }
}
