namespace Data.Entities
{
    public class BookToTag
    {
        public int Id { get; protected set; }
        public int BookId { get; protected set; }
        public int TagId { get; protected set; }
        
        public Book Book { get; protected set; }
        public Tag Tag { get; protected set; }

        public BookToTag()
        {
           
        }

        public BookToTag(int book, int tag)
        {
            BookId = book;
            TagId = tag;
        }
    }
}
