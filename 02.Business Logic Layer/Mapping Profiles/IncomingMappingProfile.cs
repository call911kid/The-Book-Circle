using AutoMapper;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.Models;

namespace The_Book_Circle._02.Business_Logic_Layer.Mapping_Profiles
{
    public class IncomingMappingProfile:Profile
    {
        public IncomingMappingProfile()
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Publisher, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                .ForMember(dest => dest.PublisherID, opt => opt.MapFrom(src => src.PublisherID))
                .ForMember(dest => dest.GenresIDs, opt => opt.MapFrom(src => src.GenresIDs));

            CreateMap<CreateAuthorDto, Author>()
                .ForMember(dest => dest.Books, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest =>dest.PhotoUrl,opt =>opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography));

            CreateMap<CreateGenreDto, Genre>()
                .ForMember(dest => dest.Books, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<CreatePublisherDto, Publisher>()
                .ForMember(dest => dest.Books, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                
        }
    }
}
