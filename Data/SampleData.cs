using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    /// <summary>
    /// Класс для начальных данных для бд
    /// </summary>
    public static class SampleData
    {
        public static void Initialize(BookContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "first book",
                        Description = "first Description"
                    },
                    new Book
                    {
                        Title = "second book",
                        Description = "second Description"
                    },
                    new Book
                    {
                        Title = "third book",
                        Description = "third Description"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
