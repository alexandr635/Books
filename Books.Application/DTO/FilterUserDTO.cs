using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class FilterUserDTO
    {
        public string Login { get; set; }

        public int PageCount { get; set; }
        public int Page { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
