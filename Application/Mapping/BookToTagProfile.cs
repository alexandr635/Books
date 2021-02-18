using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class BookToTagProfile : Profile
    {
        public BookToTagProfile()
        {
            CreateMap<BookToTag, BookToTagDTO>()
                .ReverseMap();
        }
    }
}
