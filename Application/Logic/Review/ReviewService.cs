using Application.DTO;
using Application.Mapping;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class ReviewService : IReviewService
    {
        IReviewRepository ReviewRepository { get; set; }
        IMapper mapper { get; set; }

        public ReviewService(IReviewRepository ReviewRepository, IMapper mapper)
        {
            this.ReviewRepository = ReviewRepository;
            this.mapper = mapper;
        }

        public async Task AddReview(ReviewDTO reviewDTO)
        {
            Review review = mapper.Map<Review>(reviewDTO);
            await ReviewRepository.AddReview(review);
        }
    }
}
