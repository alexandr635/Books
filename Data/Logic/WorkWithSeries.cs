using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithSeries : IWorkWithSeries
    {
        BookContext context { get; set; }

        public WorkWithSeries(BookContext context)
        {
            this.context = context;
        }

        public async Task<List<BookSeries>> GetSeries()
        {
            var result = await Task.Run( () => context.BookSeries.ToList());
            return result;
        }

        public async Task AddSeries(BookSeries bookSeries)
        {
            await Task.Run(() =>
            {
                context.BookSeries.Add(bookSeries);
                context.SaveChanges();
            });
        }
    }
}
