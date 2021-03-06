using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IBookStatusRepository
    {
        Task<List<BookStatus>> GetStatus();
        Task<BookStatus> GetStatus(int? id);
    }
}
