using Data.Entities;
using Application.DTO;
using AutoMapper;

namespace Application.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
