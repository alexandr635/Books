using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IBookSeriesRepository
    {
        Task<List<BookSeries>> GetSeries();
        Task AddSeries(BookSeries bookSeries);
        Task DeleteSeries(BookSeries series);
    }
}
