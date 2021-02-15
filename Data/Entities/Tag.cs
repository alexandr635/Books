using System.Collections.Generic;

namespace Data.Entities
{
    public class Tag
    {
        public int Id { get; protected set; }
        public string TagName { get; protected set; }

        public HashSet<Book> Books { get; protected set; }

        public Tag()
        {
            Books = new HashSet<Book>();
        }

        public Tag(int id, string tagName)
        {
            Id = id;
            TagName = tagName;
            
            Books = new HashSet<Book>();
        }

        public void SetTagName(string name)
        {
            TagName = name;
        }
    }
}
