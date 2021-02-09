using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface ISeriesRepository
    {
        Task<HashSet<BookSeries>> GetSeries();
        Task AddSeries(BookSeries bookSeries);
        Task DeleteSeries(BookSeries series);
    }
}
