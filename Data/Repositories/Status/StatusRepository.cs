using Data.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<HashSet<BookStatus>> GetStatus()
        {
            var result = await Task.Run( () => Context.BookStatuses.ToHashSet());

            return result;
        }

        public async Task<BookStatus> GetStatus(int? id)
        {
            var result = await Task.Run( () => Context.BookStatuses.FirstOrDefault(s => s.Id == id));

            return result;
        }
    }
}
