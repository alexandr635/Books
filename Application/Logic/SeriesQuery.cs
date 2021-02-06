using Application.DTO;
using Data.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class SeriesQuery : ISeriesQuery
    {
        IWorkWithSeries workWithSeries { get; set; }

        public SeriesQuery(IWorkWithSeries workWithSeries)
        {
            this.workWithSeries = workWithSeries;
        }

        public async Task<HashSet<BookSeriesDTO>> GetSeries()
        {
            var result = await workWithSeries.GetSeries();
            HashSet<BookSeriesDTO> bookSeriesDTO = new HashSet<BookSeriesDTO>();
            foreach (var series in result)
                bookSeriesDTO.Add(ConvertTo.BookSeriesDTO(series));
            
            return bookSeriesDTO;
        }

        public async Task AddSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = ConvertTo.BookSeries(bookSeriesDTO);
            await workWithSeries.AddSeries(result);
        }
    }
}
