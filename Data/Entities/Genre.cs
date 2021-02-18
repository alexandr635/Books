using System.Collections.Generic;

namespace Data.Entities
{
    public class Genre
    {
        public int Id { get; protected set; }
        public string GenreName { get; protected set; }

        public List<Book> Books { get; protected set; }

        public Genre()
        {
            Books = new List<Book>();
        }

        public Genre(int id, string genreName)
        {
            Id = id;
            GenreName = genreName;
            
            Books = new List<Book>();
        }

        public void SetGenreName(string name)
        {
            GenreName = name;
        }
    }
}
