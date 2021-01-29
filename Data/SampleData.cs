using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data
{
    /// <summary>
    /// Класс для начальных данных для бд
    /// </summary>
    public static class SampleData
    {
        public static void Initialize(BookContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "first book",
                        DescriptionShort = "first Description",
                        DescriptionLong = "first long description this fucking book"
                    },
                    new Book
                    {
                        Title = "second book",
                        DescriptionShort = "second Description",
                        DescriptionLong = "second long description this fucking book"
                    },
                    new Book
                    {
                        Title = "third book",
                        DescriptionShort = "third Description",
                        DescriptionLong = "third long description this fucking book"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
