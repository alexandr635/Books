using Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithReview : IWorkWithReview
    {
        BookContext context { get; set; }

        public WorkWithReview(BookContext context)
        {
            this.context = context;
        }

        public async Task AddReview(Review review)
        {
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }
    }
}
