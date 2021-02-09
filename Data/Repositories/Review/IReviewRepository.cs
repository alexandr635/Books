using Data.Entities;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IReviewRepository
    {
        Task AddReview(Review review);
    }
}
