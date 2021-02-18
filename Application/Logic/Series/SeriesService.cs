using Application.DTO;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class SeriesService : ISeriesService
    {
        ISeriesRepository SeriesRepository { get; set; }
        IMapper Mapper { get; set; }

        public SeriesService(ISeriesRepository SeriesRepository, IMapper mapper)
        {
            this.SeriesRepository = SeriesRepository;
            Mapper = mapper;
        }

        public async Task<List<BookSeriesDTO>> GetSeries()
        {
            var result = await SeriesRepository.GetSeries();
            List<BookSeriesDTO> bookSeriesDTO = new List<BookSeriesDTO>();

            foreach (var series in result)
                bookSeriesDTO.Add(Mapper.Map<BookSeriesDTO>(series));
            
            return bookSeriesDTO;
        }

        public async Task AddSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = Mapper.Map<BookSeries>(bookSeriesDTO);
            await SeriesRepository.AddSeries(result);
        }

        public async Task DeleteSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = Mapper.Map<BookSeries>(bookSeriesDTO);
            await SeriesRepository.DeleteSeries(result);
        }
    }
}
