using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(u => u.RoleDTO, opt => opt.MapFrom(src => src.Role))
                .ReverseMap();
        }
    }
}
