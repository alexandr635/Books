namespace Books.Domain.Entities
{
    public class UserToBook
    {
        public int Id { get; protected set; }
        public int BookId { get; protected set; }
        public int UserId { get; protected set; }

        public Book Book { get; protected set; }
        public User User { get; protected set; }

        public UserToBook()
        {

        }

        public UserToBook(int book, int user)
        {
            BookId = book;
            UserId = user;
        }
    }
}
