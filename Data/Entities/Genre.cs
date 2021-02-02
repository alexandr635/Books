using System.Collections.Generic;

namespace Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
