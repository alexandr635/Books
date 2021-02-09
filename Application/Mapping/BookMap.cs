using Application.DTO;
using Data;
using AutoMapper;

namespace Application.Mapping
{
    public class BookMap
    {
        public static Book Book(BookDTO bookDTO)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>());
            Mapper mapper = new Mapper(config);
            Book book = mapper.Map<BookDTO, Book>(bookDTO);

            return book;
        }

        public static BookDTO BookDTO(Book book)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            Mapper mapper = new Mapper(config);
            BookDTO bookDTO = mapper.Map<Book, BookDTO>(book);

            return bookDTO;
        }
    }
}
