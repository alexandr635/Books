using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Review>> GetReview(string user)
        {
            return await Context.Reviews
                .Include(r => r.User)
                .Include(r => r.Book)
                .Where(r => r.User.Login == user)
                .ToListAsync();
        }
    }
}
