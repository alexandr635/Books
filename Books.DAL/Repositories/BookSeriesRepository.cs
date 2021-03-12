using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BookSeries> GetSeries(int id)
        {
            return await Context.BookSeries
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task ChangeSeries(BookSeries series)
        {
            Context.Update(series);
            await Context.SaveChangesAsync();
        }
    }
}
