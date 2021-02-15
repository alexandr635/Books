using Data.Entities;
using Application.DTO;
using AutoMapper;

namespace Application.Mapping
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<BookStatus, BookStatusDTO>().ReverseMap();
        }
    }
}
