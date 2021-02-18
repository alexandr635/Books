using System.Collections.Generic;

namespace Data.Entities
{
    public class Tag
    {
        public int Id { get; protected set; }
        public string TagName { get; protected set; }

        public List<BookToTag> BookToTags { get; protected set; }

        public Tag()
        {
            BookToTags = new List<BookToTag>();
        }

        public Tag(int id, string tagName)
        {
            Id = id;
            TagName = tagName;

            BookToTags = new List<BookToTag>();
        }

        public void SetTagName(string name)
        {
            TagName = name;
        }
    }
}
