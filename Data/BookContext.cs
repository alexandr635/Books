using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {}

        public DbSet<Book> Books { set; get; }
    }
}
