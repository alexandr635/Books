using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }

        public RoleDTO RoleDTO { get; set; }

        public List<BookRentDTO> BookRents { get; protected set; }
        public List<UserToBookDTO> UserToBooks { get; protected set; }
    }
}
