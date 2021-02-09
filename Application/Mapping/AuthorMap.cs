using Application.DTO;
using Data.Entities;
using AutoMapper;

namespace Application.Mapping
{
    public class AuthorMap
    {
        public static Author Author(AuthorDTO authorDTO)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>());
            Mapper mapper = new Mapper(config);
            Author author = mapper.Map<AuthorDTO, Author>(authorDTO);

            return author;
        }

        public static AuthorDTO AuthorDTO(Author author)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>());
            Mapper mapper = new Mapper(config);
            AuthorDTO authorDTO = mapper.Map<Author, AuthorDTO>(author);

            return authorDTO;
        }
    }
}
