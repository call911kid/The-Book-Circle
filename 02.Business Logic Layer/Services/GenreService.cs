using AutoMapper;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreManager;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreManager, IMapper mapper)
        {
            _genreManager = genreManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            var genres = await _genreManager.GetAllAsync();
            var genreDtos = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return genreDtos;
        }
        public async Task<GenreDto> GetGenreByIdAsync(int ID)
        {
            var genre = await _genreManager.GetByIdAsync(ID)
                ?? throw new DirectoryNotFoundException("Genre not found.");

            var genreDto = _mapper.Map<GenreDto>(genre);

            return genreDto;
        }
        public async Task<GenreDto> CreateGenreAsync(CreateGenreDto createGenreDto)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);
            await _genreManager.CreateAsync(genre);

            var createdGenre = _mapper.Map<GenreDto>(genre);
            await _genreManager.SaveChangesAsync();

            return createdGenre;

        }
    }
}
