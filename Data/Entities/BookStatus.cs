using System.Collections.Generic;

namespace Data.Entities
{
    public class BookStatus
    {
        public int Id { get; protected set; }
        public string StatusName { get; protected set; }

        public HashSet<Book> Books { get; protected set; }

        public BookStatus()
        {
            Books = new HashSet<Book>();
        }

        public BookStatus(int id, string status)
        {
            Id = id;
            StatusName = status;
            
            Books = new HashSet<Book>();
        }

        public void SetStatus(string status)
        {
            StatusName = status;
        }
    }
}
