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
            await Task.Run( () =>
            {
                int bookId = review.Book.Id;
                review.Book = null;
                review.Id = 0;

                context.Reviews.Add(review);
                context.SaveChanges();

                review.Book = context.Books.FirstOrDefault(b => b.Id == bookId);
                context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            });
        }
    }
}
