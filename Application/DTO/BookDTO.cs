using System.Collections.Generic;

namespace Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public double AverageRating { get; set; }
        public byte[] Image { get; set; }

        public int AuthorId {get; set;}
        public int GenreId { get; set; }
        public int BookStatusId { get; set; }
        public int? BookSeriesId { get; set; }

        public AuthorDTO AuthorDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }
        public List<BookToTagDTO> BookToTagsDTO { get; set; }
        public BookStatusDTO BookStatusDTO { get; set; }
        public BookSeriesDTO BookSeriesDTO { get; set; }
        public List<ReviewDTO> ReviewsDTO { get; set; }

        public BookDTO()
        {
            BookToTagsDTO = new List<BookToTagDTO>();
        }
    }
}
