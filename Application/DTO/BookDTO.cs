using Data.Entities;
using System.Collections.Generic;

namespace Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }


        public int AuthorDTOId {get; set;}
        public int GenreDTOId { get; set; }
        public int BookStatusDTOId { get; set; }
        public int? BookSeriesDTOId { get; set; }

        public AuthorDTO AuthorDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }
        public HashSet<TagDTO> TagsDTO { get; set; }
        public BookStatusDTO BookStatusDTO { get; set; }
        public BookSeriesDTO BookSeriesDTO { get; set; }
        public HashSet<ReviewDTO> ReviewDTOs { get; set; }
    }
}
