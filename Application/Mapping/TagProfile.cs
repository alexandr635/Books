using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
}
