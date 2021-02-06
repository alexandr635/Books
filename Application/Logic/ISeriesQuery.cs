using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface ISeriesQuery
    {
        Task<HashSet<BookSeriesDTO>> GetSeries();
        Task AddSeries(BookSeriesDTO bookSeriesDTO);
    }
}
