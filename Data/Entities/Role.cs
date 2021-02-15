using System.Collections.Generic;

namespace Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public HashSet<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}
