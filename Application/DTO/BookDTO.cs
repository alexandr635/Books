using System.Collections.Generic;

namespace Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }

        public int AuthorId {get; set;}
        public int GenreId { get; set; }
        public int BookStatusId { get; set; }
        public int? BookSeriesId { get; set; }

        public AuthorDTO AuthorDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }
        public HashSet<TagDTO> TagsDTO { get; set; }
        public BookStatusDTO BookStatusDTO { get; set; }
        public BookSeriesDTO BookSeriesDTO { get; set; }
        public HashSet<ReviewDTO> ReviewsDTO { get; set; }
    }
}
