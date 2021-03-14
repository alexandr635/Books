namespace Books.Application.DTO
{
    public class UserToBookDTO
    {
        public int Id { get; protected set; }
        public int BookId { get; protected set; }
        public int UserId { get; protected set; }

        public BookDTO Book { get; protected set; }
    }
}
