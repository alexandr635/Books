using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithSeries
    {
        Task<List<BookSeries>> GetSeries();
        Task AddSeries(BookSeries bookSeries);
    }
}
