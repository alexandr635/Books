using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book[]{
                    new Book { Id = 1, Title = "Книга 1", DescriptionShort = "Короткое описание", DescriptionLong = "Длинное описание" },
                    new Book { Id = 2, Title = "Книга 2", DescriptionShort = "Короткое описание2", DescriptionLong = "Длинное описание2" },
                    new Book { Id = 3, Title = "Книга 3", DescriptionShort = "Короткое описание3", DescriptionLong = "Длинное описание3" }
            });
        }
    }
}
