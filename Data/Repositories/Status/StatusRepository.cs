using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class StatusRepository : IStatusRepository
    {
        BookContext Context { get; set; }

        public StatusRepository(BookContext Context)
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
