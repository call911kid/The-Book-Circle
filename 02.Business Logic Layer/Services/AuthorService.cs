using AutoMapper;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle._02.Business_Logic_Layer.Exceptions;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorManager;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorManager, IMapper mapper)
        {
            _authorManager = authorManager;
            _mapper = mapper;
        }
        public async Task<ServiceResult<IEnumerable<AuthorDto>>> GetAllAuthorsAsync()
        {
            var authors = await _authorManager.GetAllAsync();
            var authorDtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return ServiceResult<IEnumerable<AuthorDto>>
                .Success(authorDtos);
        }
        public async Task<ServiceResult<AuthorDto>> GetAuthorByIdAsync(int ID)
        {
            var author = await _authorManager.GetByIdAsync(ID)
                ?? throw new NotFoundException("Author not found");
            
            var authorDto = _mapper.Map<AuthorDto>(author);

            return ServiceResult<AuthorDto>
                .Success(authorDto);
        }
        public async Task<ServiceResult<AuthorDto>> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            await _authorManager.CreateAsync(author);

            var createdAuthor = _mapper.Map<AuthorDto>(author);
            await _authorManager.SaveChangesAsync();

            return ServiceResult<AuthorDto>
                .Success(createdAuthor);


        }
    }
}