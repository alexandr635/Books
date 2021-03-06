using Books.Domain.Entities;
using Books.Domain.Interfaces;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        ApplicationContext Context { get; set; }

        public ReviewRepository(ApplicationContext Context)
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
