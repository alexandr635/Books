using System.Collections.Generic;

namespace Data.Entities
{
    public class BookSeries
    {
        public int Id { get; protected set; }
        public string SeriesName { get; protected set; }

        public HashSet<Book> Books { get; protected set; }

        public BookSeries()
        {
            Books = new HashSet<Book>();
        }

        public BookSeries(int id, string seriesName)
        {
            Id = id;
            SeriesName = seriesName;
            
            Books = new HashSet<Book>();
        }

        public void SetSeriesName(string name)
        {
            SeriesName = name;
        }
    }
}
