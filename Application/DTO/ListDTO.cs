using System.Collections.Generic;

namespace Application.DTO
{
    public class ListDTO
    {
        public List<AuthorDTO> AuthorDTO { get; set; }
        public List<BookStatusDTO> BookStatusDTO { get; set; }
        public List<GenreDTO> GenreDTO { get; set; }
        public List<TagDTO> TagDTO { get; set; }
        public List<BookSeriesDTO> BookSeriesDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
