using Books.Domain.Entities;
using System.Collections.Generic;

namespace Books.Infrastructure.Lists
{
    public class ListEntities
    {
        public List<Author> Author { get; set; }
        public List<BookStatus> BookStatus { get; set; }
        public List<Genre> Genre { get; set; }
        public List<Tag> Tag { get; set; }
        public List<BookSeries> BookSeries { get; set; }
        public Book Book { get; set; }
    }
}
