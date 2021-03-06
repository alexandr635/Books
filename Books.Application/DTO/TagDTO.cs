using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public List<BookToTagDTO> BookToTagsDTO { get; set; }
    }
}
