using Application.DTO;
using AutoMapper;
using Data.Repositories.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Role
{
    public class RoleService : IRoleService
    {
        IRoleRepository RoleRepository { get; set; }
        IMapper Mapper { get; set; }

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            RoleRepository = roleRepository;
            Mapper = mapper;
        }

        public async Task<List<RoleDTO>> GetRole()
        {
            return Mapper.Map<List<RoleDTO>>(await RoleRepository.GetRole());
        }
    }
}
