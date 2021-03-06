using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        ApplicationContext Context { get; set; }

        public RoleRepository(ApplicationContext bookContext)
        {
            Context = bookContext;
        }

        public async Task<List<Role>> GetRole()
        {
            return await Context.Roles.ToListAsync();
        }
    }
}
