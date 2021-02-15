using Application.DTO;
using Application.Mapping;
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
        IMapper mapper { get; set; }

        public SeriesService(ISeriesRepository SeriesRepository, IMapper mapper)
        {
            this.SeriesRepository = SeriesRepository;
            this.mapper = mapper;
        }

        public async Task<HashSet<BookSeriesDTO>> GetSeries()
        {
            var result = await SeriesRepository.GetSeries();
            HashSet<BookSeriesDTO> bookSeriesDTO = new HashSet<BookSeriesDTO>();

            foreach (var series in result)
                bookSeriesDTO.Add(mapper.Map<BookSeriesDTO>(series));
            
            return bookSeriesDTO;
        }

        public async Task AddSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = mapper.Map<BookSeries>(bookSeriesDTO);
            await SeriesRepository.AddSeries(result);
        }

        public async Task DeleteSeries(BookSeriesDTO bookSeriesDTO)
        {
            var result = mapper.Map<BookSeries>(bookSeriesDTO);
            await SeriesRepository.DeleteSeries(result);
        }
    }
}
