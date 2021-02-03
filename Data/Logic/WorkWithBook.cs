using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithBook : IWorkWithBook
    {
        BookContext bookContext;

        public WorkWithBook(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public async Task<List<Book>> GetBook()
        {
            var res = Task.Run( () => bookContext.Books.ToList());
            List<Book> books = await res;
            return books;
        }

        public async Task<Book> GetBook(int? id)
        {
            var res = Task.Run( () => bookContext.Books.FirstOrDefault(b => b.Id == id));
            Book book = await res;
            return book;
        }

        public async Task AddBook(Book book)
        {
            await Task.Run(() =>
            {
               bookContext.Books.Add(book);
               bookContext.SaveChanges();
            });
        }

        public async Task ChangeBook(Book book)
        {
            await Task.Run(() =>
            {
                bookContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bookContext.SaveChanges();
            });
        }
    }
}
