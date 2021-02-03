using Data.Entities;
using System.Collections.Generic;

namespace Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public List<Tag> Tags { get; set; }
        public BookStatus BookStatus { get; set; }
        public BookSeries BookSeries { get; set; }
    }
}
