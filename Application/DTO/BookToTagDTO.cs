namespace Application.DTO
{
    public class BookToTagDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }

        public BookDTO BookDTO { get; set; }
        public TagDTO TagDTO { get; set; }

        public BookToTagDTO(int bookId, int tagId)
        {
            BookId = bookId;
            TagId = tagId;
        }
    }
}
