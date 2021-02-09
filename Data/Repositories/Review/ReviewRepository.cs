using Data.Entities;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class ReviewRepository : IReviewRepository
    {
        BookContext Context { get; set; }

        public ReviewRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public async Task AddReview(Review review)
        {
            await Context.Reviews.AddAsync(review);
            await Context.SaveChangesAsync();
        }
    }
}
