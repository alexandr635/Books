using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IStatusRepository
    {
        Task<HashSet<BookStatus>> GetStatus();
        Task<BookStatus> GetStatus(int? id);
    }
}
