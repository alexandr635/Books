using System.Collections.Generic;

namespace Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public List<Book> Books { get; set; }

        public Tag()
        {
            Books = new List<Book>();
        }
    }
}
