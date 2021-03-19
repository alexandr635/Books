using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Infrastructure.Pagination;

namespace Books.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(b => b.BookToTagsDTO, opt => opt.MapFrom(src => src.BookToTags))
                .ForMember(b => b.AuthorDTO, opt => opt.MapFrom(src => src.Author))
                .ForMember(b => b.BookStatusDTO, opt => opt.MapFrom(src => src.BookStatus))
                .ForMember(b => b.ReviewsDTO, opt => opt.MapFrom(src => src.Reviews))
                .ReverseMap();

            CreateMap<Author, AuthorDTO>()
                .ReverseMap();

            CreateMap<BookToTag, BookToTagDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreDTO>()
                .ReverseMap();

            CreateMap<Review, ReviewDTO>()
                .ForMember(r => r.BookDTO, opt => opt.MapFrom(src => src.Book))
                .ForMember(r => r.UserDTO, opt => opt.MapFrom(src => src.User))
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

            CreateMap<IndexViewModelDTO, IndexViewModel>()
                .ReverseMap();

            CreateMap<SortDTO, Book>()
                .ReverseMap();

            CreateMap<FilterBookDTO, Book>()
                .ReverseMap();

            CreateMap<FilterAuthorDTO, Author>()
                .ReverseMap();

            CreateMap<BookRentDTO, BookRent>()
                .ReverseMap();

            CreateMap<UserToBookDTO, UserToBook>()
                .ReverseMap();
        }
    }
}
