using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IBookStatusService
    {
        Task<List<BookStatus>> GetStatusByRole(string role);
    }
}
