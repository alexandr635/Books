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
            this.Mapper = mapper;
        }

        public async Task<HashSet<BookSeriesDTO>> GetSeries()
        {
            var result = await SeriesRepository.GetSeries();
            HashSet<BookSeriesDTO> bookSeriesDTO = new HashSet<BookSeriesDTO>();

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
