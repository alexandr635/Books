using Data.Entities;
using System;
using System.Collections.Generic;

namespace Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public DateTime PublishDate { get; set; }
        public double AverageRating { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public List<Tag> Tags { get; set; }
        public BookStatus BookStatus { get; set; }
        public BookSeries BookSeries { get; set; }
        public List<Review> Reviews { get; set; }

        public Book()
        {
            Tags = new List<Tag>();
            Reviews = new List<Review>();
        }
    }
}
