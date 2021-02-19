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
            return Mapper.Map<List<BookSeriesDTO>>(await SeriesRepository.GetSeries());
        }

        public async Task AddSeries(BookSeriesDTO bookSeriesDTO)
        {
            await SeriesRepository.AddSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
        }

        public async Task DeleteSeries(BookSeriesDTO bookSeriesDTO)
        {
            await SeriesRepository.DeleteSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
        }
    }
}
