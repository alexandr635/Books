using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface ISeriesService
    {
        Task<HashSet<BookSeriesDTO>> GetSeries();
        Task AddSeries(BookSeriesDTO bookSeriesDTO);
        Task DeleteSeries(BookSeriesDTO bookSeriesDTO);
    }
}
