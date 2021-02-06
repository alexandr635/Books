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
            bookDTO.AuthorDTO = AuthorDTO(book.Author);
            bookDTO.GenreDTO = GenreDTO(book.Genre);
            //bookDTO.TagsDTO = TagDTO(book.Tags);
            //bookDTO.BookSeries = book.BookSeries;
            bookDTO.BookStatusDTO = BookStatusDTO(book.BookStatus);

            return bookDTO;
        }

        public static Book Book(BookDTO bookDTO)
        {
            Book book = new Book();
            book.Id = bookDTO.Id;
            book.Title = bookDTO.Title;
            book.DescriptionLong = bookDTO.DescriptionLong;
            book.DescriptionShort = bookDTO.DescriptionShort;
            book.Author = Author(bookDTO.AuthorDTO);
            book.Genre = Genre(bookDTO.GenreDTO);
            //book.Tags = bookDTO.Tags;
            //book.BookSeries = bookDTO.BookSeries;
            book.BookStatus = BookStatus(bookDTO.BookStatusDTO);

            return book;
        }

        public static BookStatus BookStatus(BookStatusDTO bookStatusDTO)
        {
            BookStatus bookStatus = new BookStatus();
            bookStatus.Id = bookStatusDTO.Id;
            bookStatus.StatusName = bookStatusDTO.StatusName;

            return bookStatus;
        }

        public static BookStatusDTO BookStatusDTO(BookStatus bookStatus)
        {
            BookStatusDTO bookStatusDTO = new BookStatusDTO();
            bookStatusDTO.Id = bookStatus.Id;
            bookStatusDTO.StatusName = bookStatus.StatusName;

            return bookStatusDTO;
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

        public static TagDTO TagDTO(Tag tag)
        {
            TagDTO tagDTO = new TagDTO();
            tagDTO.Id = tag.Id;
            tagDTO.TagName = tag.TagName;
            return tagDTO;
        }

        public static Tag Tag(TagDTO tagDTO)
        {
            Tag tag = new Tag();
            tag.Id = tagDTO.Id;
            tag.TagName = tagDTO.TagName;
            return tag;
        }

        public static BookSeriesDTO BookSeriesDTO(BookSeries bookSeries)
        {
            BookSeriesDTO bookSeriesDTO = new BookSeriesDTO();
            bookSeriesDTO.Id = bookSeries.Id;
            bookSeriesDTO.SeriesName = bookSeries.SeriesName;
            foreach (var book in bookSeries.Books)
                bookSeriesDTO.BooksDTO.Add(ConvertTo.BookDTO(book));

            return bookSeriesDTO;
        }

        public static BookSeries BookSeries(BookSeriesDTO bookSeriesDTO)
        {
            BookSeries bookSeries = new BookSeries();
            bookSeries.Id = bookSeriesDTO.Id;
            bookSeries.SeriesName = bookSeriesDTO.SeriesName;
            foreach (var book in bookSeriesDTO.BooksDTO)
                bookSeries.Books.Add(ConvertTo.Book(book));

            return bookSeries;
        }

        public static Review Review(ReviewDTO reviewDTO)
        {
            Review review = new Review();
            review.Id = reviewDTO.Id;
            review.Pseudonim = reviewDTO.Pseudonim;
            review.ReviewString = reviewDTO.ReviewString;
            review.Rating = reviewDTO.Rating;
            review.Book = Book(reviewDTO.Book);

            return review;
        }
    }
}
