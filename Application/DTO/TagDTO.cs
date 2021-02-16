using System.Collections.Generic;

namespace Application.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public HashSet<BookDTO> BooksDTO { get; set; }
    }
}
