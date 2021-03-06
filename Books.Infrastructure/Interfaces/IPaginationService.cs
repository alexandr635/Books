using Books.Domain.Entities;
using Books.Infrastructure.Pagination;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IPaginationService
    {
        Task<IndexViewModel> GetPaginationModel(Book pattern, string tagsId, int page);
    }
}
