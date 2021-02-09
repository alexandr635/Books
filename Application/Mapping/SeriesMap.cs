using Application.DTO;
using Data.Entities;
using AutoMapper;

namespace Application.Mapping
{
    public class SeriesMap
    {
        public static BookSeries BookSeries(BookSeriesDTO seriesDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookSeriesDTO, BookSeries>());
            var mapper = new Mapper(config);
            BookSeries bookSeries = mapper.Map<BookSeriesDTO, BookSeries>(seriesDTO);

            return bookSeries;
        }

        public static BookSeriesDTO BookSeriesDTO(BookSeries series)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookSeries, BookSeriesDTO>());
            var mapper = new Mapper(config);
            BookSeriesDTO bookSeriesDTO = mapper.Map<BookSeries, BookSeriesDTO>(series);

            return bookSeriesDTO;
        }
    }
}
