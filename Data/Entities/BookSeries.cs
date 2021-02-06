using System.Collections.Generic;

namespace Data.Entities
{
    public class BookSeries
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }

        public HashSet<Book> Books { get; set; }

        public BookSeries()
        {
            Books = new HashSet<Book>();
        }
    }
}
