using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRole();
    }
}
