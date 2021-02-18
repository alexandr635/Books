using System.Collections.Generic;

namespace Data.Entities
{
    public class BookStatus
    {
        public int Id { get; protected set; }
        public string StatusName { get; protected set; }

        public List<Book> Books { get; protected set; }

        public BookStatus()
        {
            Books = new List<Book>();
        }

        public BookStatus(int id, string status)
        {
            Id = id;
            StatusName = status;
            
            Books = new List<Book>();
        }

        public void SetStatus(string status)
        {
            StatusName = status;
        }
    }
}
