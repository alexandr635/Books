using Application.DTO;
using AutoMapper;
using Data;
using Data.Entities;

namespace Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(b => b.BookToTagsDTO, opt => opt.MapFrom(src => src.BookToTags))
                .ReverseMap();

            CreateMap<Author, AuthorDTO>()
                .ReverseMap();

            CreateMap<BookToTag, BookToTagDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreDTO>()
                .ReverseMap();

            CreateMap<Review, ReviewDTO>()
                .ReverseMap();

            CreateMap<Role, RoleDTO>()
                .ReverseMap();

            CreateMap<BookSeries, BookSeriesDTO>()
                .ReverseMap();

            CreateMap<BookStatus, BookStatusDTO>()
                .ReverseMap();

            CreateMap<Tag, TagDTO>()
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(u => u.RoleDTO, opt => opt.MapFrom(src => src.Role))
                .ReverseMap();
        }
    }
}
