using Data.Entities;
using Application.DTO;
using AutoMapper;

namespace Application.Mapping
{
    public class SeriesProfile : Profile
    {
        public SeriesProfile()
        {
            CreateMap<BookSeries, BookSeriesDTO>().ReverseMap();
        }
    }
}
