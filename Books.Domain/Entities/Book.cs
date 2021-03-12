using System;
using System.Collections.Generic;

namespace Books.Domain.Entities
{
    public class Book
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string DescriptionShort { get; protected set; }
        public string DescriptionLong { get; protected set; }
        public DateTime PublishDate { get; protected set; }
        public double AverageRating { get; protected set; }
        public byte[] Image { get; protected set; }

        public int AuthorId { get; protected set; }
        public int GenreId { get; protected set; }
        public int BookStatusId { get; protected set; }
        public int? BookSeriesId { get; protected set; }

        public Author Author { get; protected set; }
        public Genre Genre { get; protected set; }
        public BookStatus BookStatus { get; protected set; }
        public BookSeries BookSeries { get; protected set; }
        public List<Review> Reviews { get; protected set; }
        public List<BookToTag> BookToTags { get; protected set; }
        public List<UserToBook> UserToBooks { get; protected set; }

        public Book(int id, string title, string sDesc, string lDesc, DateTime publishDate, double averageRating,
                    int author, int genre, int status, int? series)
        {
            Id = id;
            Title = title;
            DescriptionShort = sDesc;
            DescriptionLong = lDesc;
            PublishDate = publishDate;
            AverageRating = averageRating;

            AuthorId = author;
            GenreId = genre;
            BookStatusId = status;
            BookSeriesId = series;

            Reviews = new List<Review>();
            BookToTags = new List<BookToTag>();
            UserToBooks = new List<UserToBook>();
        }

        public Book(int id)
        {
            Id = id;
            Reviews = new List<Review>();
            BookToTags = new List<BookToTag>();
            UserToBooks = new List<UserToBook>();
        }

        public Book(string title, int author, int genre, double rating)
        {
            Title = title;
            AuthorId = author;
            GenreId = genre;
            AverageRating = rating;
        }

        public Book()
        {
            Reviews = new List<Review>();
            BookToTags = new List<BookToTag>();
            UserToBooks = new List<UserToBook>();
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetShortDescription(string description)
        {
            DescriptionShort = description;
        }

        public void SetLongDescription(string description)
        {
            DescriptionLong = description;
        }

        public void SetPublishDate(DateTime date)
        {
            PublishDate = date;
        }

        public void SetAverageRating(int rating)
        {
            AverageRating = rating;
        }

        public void SetAuthorId(int id)
        {
            AuthorId = id;
        }

        public void SetGenreId(int id)
        {
            GenreId = id;
        }

        public void SetStatusId(int id)
        {
            BookStatusId = id;
        }

        public void SetSeriesId(int? id)
        {
            BookSeriesId = id;
        }

        public void SetImage(byte[] img)
        {
            Image = img;
        }

        public void SetBookToTags(List<BookToTag> list)
        {
            BookToTags = list;
        }
    }
}
