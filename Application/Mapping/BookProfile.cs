using Application.DTO;
using AutoMapper;
using Data;

namespace Application.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(b => b.TagsDTO, opt => opt.MapFrom(src => src.Tags))
                .ReverseMap();
        }
    }
}
