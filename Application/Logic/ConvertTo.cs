using Application.DTO;
using Data;
using Data.Entities;

namespace Application.Logic
{
    public class ConvertTo
    {
        public static BookDTO BookDTO(Book book)
        {
            if (book != null)
            {
                BookDTO bookDTO = new BookDTO();
                bookDTO.Id = book.Id;
                bookDTO.Title = book.Title;
                bookDTO.DescriptionLong = book.DescriptionLong;
                bookDTO.DescriptionShort = book.DescriptionShort;

                bookDTO.AuthorDTOId = book.AuthorId;
                bookDTO.GenreDTOId = book.GenreId;
                bookDTO.BookStatusDTOId = book.BookStatusId;
                bookDTO.BookSeriesDTOId = book.BookSeriesId;

                bookDTO.AuthorDTO = AuthorDTO(book.Author);
                bookDTO.GenreDTO = GenreDTO(book.Genre);
                //bookDTO.TagsDTO = TagDTO(book.Tags);
                bookDTO.BookStatusDTO = BookStatusDTO(book.BookStatus);

                return bookDTO;
            }
            else
                return null;
        }

        public static Book Book(BookDTO bookDTO)
        {
            if (bookDTO != null)
            {
                Book book = new Book();
                book.Id = bookDTO.Id;
                book.Title = bookDTO.Title;
                book.DescriptionLong = bookDTO.DescriptionLong;
                book.DescriptionShort = bookDTO.DescriptionShort;

                book.AuthorId = bookDTO.AuthorDTOId;
                book.GenreId = bookDTO.GenreDTOId;
                book.BookStatusId = bookDTO.BookStatusDTOId;
                book.BookSeriesId = bookDTO.BookSeriesDTOId;

                book.Author = Author(bookDTO.AuthorDTO);
                book.Genre = Genre(bookDTO.GenreDTO);
                //book.Tags = bookDTO.Tags;
                book.BookStatus = BookStatus(bookDTO.BookStatusDTO);

                return book;
            }
            else
                return null;
        }

        public static BookStatus BookStatus(BookStatusDTO bookStatusDTO)
        {
            if (bookStatusDTO != null)
            {
                BookStatus bookStatus = new BookStatus();
                bookStatus.Id = bookStatusDTO.Id;
                bookStatus.StatusName = bookStatusDTO.StatusName;

                return bookStatus;
            }
            else
                return null;
        }

        public static BookStatusDTO BookStatusDTO(BookStatus bookStatus)
        {
            if (bookStatus != null)
            {
                BookStatusDTO bookStatusDTO = new BookStatusDTO();
                bookStatusDTO.Id = bookStatus.Id;
                bookStatusDTO.StatusName = bookStatus.StatusName;

                return bookStatusDTO;
            }
            else
                return null;
        }

        public static GenreDTO GenreDTO(Genre genre)
        {
            if (genre != null)
            {
                GenreDTO genreDTO = new GenreDTO();
                genreDTO.Id = genre.Id;
                genreDTO.GenreName = genre.GenreName;
                return genreDTO;
            }
            else
                return null;
        }

        public static Genre Genre(GenreDTO genreDTO)
        {
            if (genreDTO != null)
            {
                Genre genre = new Genre();
                genre.Id = genreDTO.Id;
                genre.GenreName = genreDTO.GenreName;
                return genre;
            }
            else
                return null;
        }

        public static AuthorDTO AuthorDTO(Author author)
        {
            if (author != null)
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
            else
                return null;
        }

        public static Author Author(AuthorDTO authorDTO)
        {
            if (authorDTO != null)
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
            else return null;
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
            if (bookSeries != null)
            {
                BookSeriesDTO bookSeriesDTO = new BookSeriesDTO();
                bookSeriesDTO.Id = bookSeries.Id;
                bookSeriesDTO.SeriesName = bookSeries.SeriesName;
                foreach (var book in bookSeries.Books)
                    bookSeriesDTO.BooksDTO.Add(BookDTO(book));

                return bookSeriesDTO;
            }
            else
                return null;
        }

        public static BookSeries BookSeries(BookSeriesDTO bookSeriesDTO)
        {
            if (bookSeriesDTO != null)
            {
                BookSeries bookSeries = new BookSeries();
                bookSeries.Id = bookSeriesDTO.Id;
                bookSeries.SeriesName = bookSeriesDTO.SeriesName;
                foreach (var book in bookSeriesDTO.BooksDTO)
                    bookSeries.Books.Add(Book(book));

                return bookSeries;
            }
            return null;
        }

        public static Review Review(ReviewDTO reviewDTO)
        {
            if (reviewDTO != null)
            {
                Review review = new Review();
                review.Id = reviewDTO.Id;
                review.Pseudonim = reviewDTO.Pseudonim;
                review.ReviewString = reviewDTO.ReviewString;
                review.Rating = reviewDTO.Rating;
                review.BookId = reviewDTO.BookDTOId;
                review.Book = Book(reviewDTO.Book);

                return review;
            }
            else
                return null;
        }
    }
}
