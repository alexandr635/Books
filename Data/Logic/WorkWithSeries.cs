using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<HashSet<BookSeries>> GetSeries()
        {
            var result = await Task.Run( () => context.BookSeries.Include("Books").ToHashSet());
            return result;
        }

        public async Task AddSeries(BookSeries bookSeries)
        {
            await context.BookSeries.AddAsync(bookSeries);
            await context.SaveChangesAsync();
        }
    }
}
