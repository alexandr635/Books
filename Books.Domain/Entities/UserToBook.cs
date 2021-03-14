using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Entities
{
    public class UserToBook
    {
        public int Id { get; protected set; }
        public int BookId { get; protected set; }
        public int UserId { get; protected set; }

        [ForeignKey("BookId")]
        public Book Book { get; protected set; }

        [ForeignKey("UserId")]
        public User User { get; protected set; }

        public UserToBook()
        {

        }

        public UserToBook(int book, int user)
        {
            BookId = book;
            UserId = user;
        }

        public UserToBook(int bookId, int userId, Book book, User user)
        {
            BookId = bookId;
            UserId = userId;
            Book = book;
            User = user;
        }

        public void SetBook(Book book)
        {
            Book = book;
        }
    }
}
