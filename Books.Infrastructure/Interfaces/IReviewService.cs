using Books.Domain.Entities;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IReviewService
    {
        Task AddReview(string name, Review review);
    }
}
