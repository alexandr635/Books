using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Role
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetRole();
    }
}
