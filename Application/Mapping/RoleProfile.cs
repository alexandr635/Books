using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();
        }
    }
}
