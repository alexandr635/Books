using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class ReviewService : IReviewService
    {
        IUserRepository UserRepository { get; set; }
        IReviewRepository ReviewRepository { get; set; }

        public ReviewService(IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            UserRepository = userRepository;
            ReviewRepository = reviewRepository;
        }

        public async Task AddReview(string name, Review review)
        {
            var user = await UserRepository.GetUser(name);
            review.SetUser(user.Id);
            review.SetPseudonim(name);
            await ReviewRepository.AddReview(review);
        }
    }
}
