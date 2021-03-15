using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task AddReview(Review review);
        Task<List<Review>> GetReview(string user);
    }
}
