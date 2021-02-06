using System.Collections.Generic;

namespace Data.Entities
{
    public class BookStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public HashSet<Book> Books { get; set; }

        public BookStatus()
        {
            Books = new HashSet<Book>();
        }
    }
}
