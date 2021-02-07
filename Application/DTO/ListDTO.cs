using System.Collections.Generic;

namespace Application.DTO
{
    public class ListDTO
    {
        public HashSet<AuthorDTO> AuthorDTO { get; set; }
        public HashSet<BookStatusDTO> BookStatusDTO { get; set; }
        public HashSet<GenreDTO> GenreDTO { get; set; }
        public HashSet<TagDTO> TagDTO { get; set; }
        public HashSet<BookSeriesDTO> BookSeriesDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
