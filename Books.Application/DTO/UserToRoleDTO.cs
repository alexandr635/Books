using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class UserToRoleDTO
    {
        public UserDTO User { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
