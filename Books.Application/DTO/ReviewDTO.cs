namespace Books.Application.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string ReviewString { get; set; }
        public double Rating { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }

        public BookDTO BookDTO { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
