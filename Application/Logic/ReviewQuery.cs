using Application.DTO;
using Data.Entities;
using Data.Logic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class ReviewQuery : IReviewQuery
    {
        IWorkWithReview workWithReview { get; set; }

        public ReviewQuery(IWorkWithReview workWithReview)
        {
            this.workWithReview = workWithReview;
        }

        public async Task AddReview(ReviewDTO reviewDTO)
        {
            Review review = ConvertTo.Review(reviewDTO);
            await workWithReview.AddReview(review);
        }
    }
}
