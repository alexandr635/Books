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


        public AuthorDTO AuthorDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }
        public List<TagDTO> TagsDTO { get; set; }
        public BookStatusDTO BookStatusDTO { get; set; }
        public BookSeries BookSeries { get; set; }
        public List<ReviewDTO> ReviewDTOs { get; set; }
    }
}
