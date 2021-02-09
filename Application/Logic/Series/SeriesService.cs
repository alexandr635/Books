using Application.DTO;
using Application.Mapping;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class SeriesService : ISeriesService
    {
        ISeriesRepository SeriesRepository { get; set; }

        public SeriesService(ISeriesRepository SeriesRepository)
        {
            this.SeriesRepository = SeriesRepository;
        }

        public async Task<HashSet<BookSeriesDTO>> GetSeries()
        {
            var result = await SeriesRepository.GetSeries();
            HashSet<BookSeriesDTO> bookSeriesDTO = new HashSet<BookSeriesDTO>();

            foreach (var series in result)
                bookSeriesDTO.Add(SeriesMap.BookSeriesDTO(series));
            
            return bookSeriesDTO;
        }

        public async Task AddSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = SeriesMap.BookSeries(bookSeriesDTO);
            await SeriesRepository.AddSeries(result);
        }

        public async Task DeleteSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = SeriesMap.BookSeries(bookSeriesDTO);
            await SeriesRepository.DeleteSeries(result);
        }
    }
}
