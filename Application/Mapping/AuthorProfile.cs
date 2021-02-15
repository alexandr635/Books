using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
