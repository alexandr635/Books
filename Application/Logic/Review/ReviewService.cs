using Application.DTO;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class ReviewService : IReviewService
    {
        IReviewRepository ReviewRepository { get; set; }
        IMapper Mapper { get; set; }

        public ReviewService(IReviewRepository ReviewRepository, IMapper mapper)
        {
            this.ReviewRepository = ReviewRepository;
            Mapper = mapper;
        }

        public async Task AddReview(ReviewDTO reviewDTO)
        {
            Review review = Mapper.Map<Review>(reviewDTO);
            await ReviewRepository.AddReview(review);
        }
    }
}
