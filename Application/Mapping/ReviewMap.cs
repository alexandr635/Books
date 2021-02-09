using Application.DTO;
using Data.Entities;
using AutoMapper;

namespace Application.Mapping
{
    public class ReviewMap
    {
        public static Review Review(ReviewDTO reviewDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = new Mapper(config);
            Review review = mapper.Map<ReviewDTO, Review>(reviewDTO);

            return review;
        }

        public static ReviewDTO ReviewDTO(Review review)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            ReviewDTO reviewDTO = mapper.Map<Review, ReviewDTO>(review);

            return reviewDTO;
        }
    }
}
