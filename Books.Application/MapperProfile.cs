using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Infrastructure.Lists;
using Books.Infrastructure.Pagination;

namespace Books.Application
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

            CreateMap<ListDTO, ListEntities>()
                .ForMember(d => d.Author, opt => opt.MapFrom(src => src.AuthorDTO))
                .ForMember(d => d.Book, opt => opt.MapFrom(src => src.BookDTO))
                .ForMember(d => d.BookSeries, opt => opt.MapFrom(src => src.BookSeriesDTO))
                .ForMember(d => d.BookStatus, opt => opt.MapFrom(src => src.BookStatusDTO))
                .ForMember(d => d.Genre, opt => opt.MapFrom(src => src.GenreDTO))
                .ForMember(d => d.Tag, opt => opt.MapFrom(src => src.TagDTO))
                .ReverseMap();

            CreateMap<UserToRoleDTO, UserToRoles>()
                .ForMember(d => d.User, opt => opt.MapFrom(src => src.User))
                .ForMember(d => d.Roles, opt => opt.MapFrom(src => src.Roles))
                .ReverseMap();

            CreateMap<IndexViewModelDTO, IndexViewModel>()
                .ReverseMap();

            CreateMap<SortDTO, Book>()
                .ReverseMap();
        }
    }
}
