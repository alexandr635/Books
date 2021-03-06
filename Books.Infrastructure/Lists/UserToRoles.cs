using Books.Domain.Entities;
using System.Collections.Generic;

namespace Books.Infrastructure.Lists
{
    public class UserToRoles
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
    }
}
