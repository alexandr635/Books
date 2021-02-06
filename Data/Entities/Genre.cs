using System.Collections.Generic;

namespace Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public HashSet<Book> Books { get; set; }

        public Genre()
        {
            Books = new HashSet<Book>();
        }
    }
}
