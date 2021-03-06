using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class BookStatusRepository : IBookStatusRepository
    {
        ApplicationContext Context { get; set; }

        public BookStatusRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<BookStatus>> GetStatus()
        {
            return await Context.BookStatuses.ToListAsync();
        }

        public async Task<BookStatus> GetStatus(int? id)
        {
            return await Context.BookStatuses.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
