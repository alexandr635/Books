using System.Collections.Generic;

namespace Data.Entities
{
    public class Role
    {
        public int Id { get; protected set; }
        public string RoleName { get; protected set; }

        public HashSet<User> Users { get; protected set; }

        public Role()
        {
            Users = new HashSet<User>();
        }

        public Role(int id, string role)
        {
            Id = id;
            RoleName = role;
            
            Users = new HashSet<User>();
        }

        public void SetRole(string role)
        {
            RoleName = role;
        }
    }
}
