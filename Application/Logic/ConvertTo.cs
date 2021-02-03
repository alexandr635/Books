using Application.DTO;
using Data;
using Data.Entities;

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
            bookDTO.Author = book.Author;
            bookDTO.Genre = book.Genre;
            bookDTO.Tags = book.Tags;
            bookDTO.BookSeries = book.BookSeries;
            bookDTO.BookStatus = book.BookStatus;

            return bookDTO;
        }

        public static Book Book(BookDTO bookDTO)
        {
            Book book = new Book();
            book.Id = bookDTO.Id;
            book.Title = bookDTO.Title;
            book.DescriptionLong = bookDTO.DescriptionLong;
            book.DescriptionShort = bookDTO.DescriptionShort;
            book.Author = bookDTO.Author;
            book.Genre = bookDTO.Genre;
            book.Tags = bookDTO.Tags;
            book.BookSeries = bookDTO.BookSeries;
            book.BookStatus = bookDTO.BookStatus;

            return book;
        }

        public static GenreDTO GenreDTO(Genre genre)
        {
            GenreDTO genreDTO = new GenreDTO();
            genreDTO.Id = genre.Id;
            genreDTO.GenreName = genre.GenreName;
            return genreDTO;
        }

        public static Genre Genre(GenreDTO genreDTO)
        {
            Genre genre = new Genre();
            genre.Id = genreDTO.Id;
            genre.GenreName = genreDTO.GenreName;
            return genre;
        }

        public static AuthorDTO AuthorDTO(Author author)
        {
            AuthorDTO authorDTO = new AuthorDTO();
            authorDTO.Id = author.Id;
            authorDTO.Name = author.Name;
            authorDTO.LastName = author.LastName;
            authorDTO.Patronymic = author.Patronymic;
            authorDTO.DateOfBirth = author.DateOfBirth;
            authorDTO.PlaceOfBirth = author.PlaceOfBirth;
            authorDTO.Biography = author.Biography;

            return authorDTO;
        }

        public static Author Author(AuthorDTO authorDTO)
        {
            Author author = new Author();
            author.Id = authorDTO.Id;
            author.Name = authorDTO.Name;
            author.LastName = authorDTO.LastName;
            author.Patronymic = authorDTO.Patronymic;
            author.DateOfBirth = authorDTO.DateOfBirth;
            author.PlaceOfBirth = authorDTO.PlaceOfBirth;
            author.Biography = authorDTO.Biography;

            return author;
        }
    }
}
