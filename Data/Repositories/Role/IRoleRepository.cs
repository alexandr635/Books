using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Role
{
    public interface IRoleRepository
    {
        Task<List<Entities.Role>> GetRole();
    }
}
