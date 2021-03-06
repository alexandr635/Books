using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<UserDTO> UsersDTO { get; set; }

        public RoleDTO()
        {
            UsersDTO = new List<UserDTO>();
        }
    }
}
