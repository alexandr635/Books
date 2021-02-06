using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithStatus : IWorkWithStatus
    {
        BookContext context { get; set; }

        public WorkWithStatus(BookContext context)
        {
            this.context = context;
        }

        public async Task<List<BookStatus>> GetStatus()
        {
            var result = await Task.Run( () => context.BookStatuses.ToList());
            return result;
        }

        public async Task<BookStatus> GetStatus(int? id)
        {
            var result = await Task.Run( () => context.BookStatuses.FirstOrDefault(s => s.Id == id));
            return result;
        }
    }
}
