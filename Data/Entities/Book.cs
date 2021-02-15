using Data.Entities;
using System;
using System.Collections.Generic;

namespace Data
{
    public class Book
    {
        public int Id { get; internal set; }
        public string Title { get; internal set; }
        public string DescriptionShort { get; internal set; }
        public string DescriptionLong { get; internal set; }
        public DateTime PublishDate { get; internal set; }
        public double AverageRating { get; internal set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int BookStatusId { get; set; }
        public int? BookSeriesId { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public HashSet<Tag> Tags { get; set; }
        public BookStatus BookStatus { get; set; }
        public BookSeries BookSeries { get; set; }
        public HashSet<Review> Reviews { get; set; }

        public Book()
        {
            Tags = new HashSet<Tag>();
            Reviews = new HashSet<Review>();
        }
    }
}
