using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserToRoleDTO
    {
        public UserDTO User { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
