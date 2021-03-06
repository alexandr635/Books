using Books.Domain.Entities;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task AddReview(Review review);
    }
}
