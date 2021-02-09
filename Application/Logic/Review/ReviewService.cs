using Application.DTO;
using Application.Mapping;
using Data.Entities;
using Data.Logic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class ReviewService : IReviewService
    {
        IReviewRepository ReviewRepository { get; set; }

        public ReviewService(IReviewRepository ReviewRepository)
        {
            this.ReviewRepository = ReviewRepository;
        }

        public async Task AddReview(ReviewDTO reviewDTO)
        {
            Review review = ReviewMap.Review(reviewDTO);
            await ReviewRepository.AddReview(review);
        }
    }
}
