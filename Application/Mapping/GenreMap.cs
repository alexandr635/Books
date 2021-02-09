using Application.DTO;
using Data.Entities;
using AutoMapper;

namespace Application.Mapping
{
    public class GenreMap
    {
        public static Genre Genre(GenreDTO genreDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>());
            var mapper = new Mapper(config);
            Genre genre = mapper.Map<GenreDTO, Genre>(genreDTO);

            return genre;
        }

        public static GenreDTO GenreDTO(Genre genre)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>());
            var mapper = new Mapper(config);
            GenreDTO genreDTO = mapper.Map<Genre, GenreDTO>(genre);

            return genreDTO;
        }
    }
}
