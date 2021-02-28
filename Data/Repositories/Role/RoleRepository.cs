using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        BookContext Context { get; set; }

        public RoleRepository(BookContext bookContext)
        {
            Context = bookContext;
        }

        public async Task<List<Entities.Role>> GetRole()
        {
            return await Context.Roles.ToListAsync();
        }
    }
}
