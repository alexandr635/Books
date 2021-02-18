using System.Collections.Generic;

namespace Data.Entities
{
    public class BookSeries
    {
        public int Id { get; protected set; }
        public string SeriesName { get; protected set; }

        public List<Book> Books { get; protected set; }

        public BookSeries()
        {
            Books = new List<Book>();
        }

        public BookSeries(int id, string seriesName)
        {
            Id = id;
            SeriesName = seriesName;
            
            Books = new List<Book>();
        }

        public void SetSeriesName(string name)
        {
            SeriesName = name;
        }
    }
}
