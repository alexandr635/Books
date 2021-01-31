using Application.DTO;
using Data;

namespace Application.Logic
{
    public class ConvertTo
    {
        public static BookDTO BookDTO(Book book)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = book.Id;
            bookDTO.Title = book.Title;
            bookDTO.DescriptionLong = book.DescriptionLong;
            bookDTO.DescriptionShort = book.DescriptionShort;

            return bookDTO;
        }

        public static Book Book(BookDTO bookDTO)
        {
            Book book = new Book();
            book.Id = bookDTO.Id;
            book.Title = bookDTO.Title;
            book.DescriptionLong = bookDTO.DescriptionLong;
            book.DescriptionShort = bookDTO.DescriptionShort;

            return book;
        }
    }
}
