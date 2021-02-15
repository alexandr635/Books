using System.Collections.Generic;

namespace Application.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public HashSet<UserDTO> UsersDTO { get; set; }

        public RoleDTO()
        {
            UsersDTO = new HashSet<UserDTO>();
        }
    }
}
