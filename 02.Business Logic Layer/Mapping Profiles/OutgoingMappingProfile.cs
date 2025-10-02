using AutoMapper;
using The_Book_Circle.DTOs;
using The_Book_Circle.Models;

namespace The_Book_Circle._02.Business_Logic_Layer.Mapping_Profiles
{
    public class OutgoingMappingProfile:Profile
    {
        public OutgoingMappingProfile()
        {
            CreateMap<Book,BookDto>()
                .ForMember(dest=>dest.ID,opt=>opt.MapFrom(src=>src.ID))
                .ForMember(dest=>dest.ISBN, opt=>opt.MapFrom(src=>src.ISBN))
                .ForMember(dest=>dest.Title,opt=>opt.MapFrom(src=>src.Title))
                .ForMember(dest=>dest.Subtitle,opt=>opt.MapFrom(src=>src.Subtitle))
                .ForMember(dest=>dest.Description,opt=>opt.MapFrom(src=>src.Description))
                .ForMember(dest=>dest.Pages,opt=>opt.MapFrom(src=>src.Pages))
                .ForMember(dest=>dest.Language,opt=>opt.MapFrom(src=>src.Language))
                .ForMember(dest=>dest.CoverImageUrl,opt=>opt.MapFrom(src=>src.CoverImageUrl))
                .ForMember(dest=>dest.PublicationDate,opt=>opt.MapFrom(src=>src.PublicationDate))
                .ForMember(dest=>dest.AuthorID,opt=>opt.MapFrom(src=>src.AuthorID))
                .ForMember(dest=>dest.PublisherID,opt=>opt.MapFrom(src=>src.PublisherID))
                .ForMember(dest=>dest.GenresIDs,opt=>opt.MapFrom(src=>src.Genres.Select(g=>g.ID)));

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography));

            CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                





        }
    }
}
