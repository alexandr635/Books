using System.Collections.Generic;

namespace Data.Entities
{
    public class Role
    {
        public int Id { get; protected set; }
        public string RoleName { get; protected set; }

        public List<User> Users { get; protected set; }

        public Role()
        {
            Users = new List<User>();
        }

        public Role(int id, string role)
        {
            Id = id;
            RoleName = role;
            
            Users = new List<User>();
        }

        public void SetRole(string role)
        {
            RoleName = role;
        }
    }
}
