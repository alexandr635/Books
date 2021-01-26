using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            //исключение
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { set; get; }
    }
}
