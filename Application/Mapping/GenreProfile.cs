using AutoMapper;
using Data.Entities;
using Application.DTO;

namespace Application.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
