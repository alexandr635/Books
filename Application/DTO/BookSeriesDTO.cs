using System.Collections.Generic;

namespace Application.DTO
{
    public class BookSeriesDTO
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }

        public HashSet<BookDTO> BooksDTO { get; set; }

        public BookSeriesDTO()
        {
            BooksDTO = new HashSet<BookDTO>();
        }
    }
}
