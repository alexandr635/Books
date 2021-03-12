using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class FilterBookDTO
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public double AverageRating { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }

        public List<BookDTO> Books { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<GenreDTO> Genres { get; set; }

    }
}
