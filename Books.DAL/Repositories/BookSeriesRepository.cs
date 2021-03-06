using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class BookSeriesRepository : IBookSeriesRepository
    {
        ApplicationContext Context { get; set; }

        public BookSeriesRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<BookSeries>> GetSeries()
        {
            return await Context.BookSeries
                .Include(s => s.Books)
                .ToListAsync();
        }

        public async Task AddSeries(BookSeries bookSeries)
        {
            await Context.BookSeries.AddAsync(bookSeries);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteSeries(BookSeries series)
        {
            Context.BookSeries.Remove(series);
            await Context.SaveChangesAsync();
        }
    }
}
