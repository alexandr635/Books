using Microsoft.EntityFrameworkCore;
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
            var res = Task.Run( () => bookContext.Books.Include("Author").Include("Genre").Include("BookStatus").ToList());
            List<Book> books = await res;
            
            return books;
        }

        public async Task<Book> GetBook(int? id)
        {
            var res = Task.Run( () => bookContext.Books.AsNoTracking().Include("Author").Include("Genre").Include("BookStatus").FirstOrDefault(b => b.Id == id));
            Book book = await res;
            return book;
        }

        public async Task AddBook(Book book)
        {
            await Task.Run(() =>
            {
                int AuthorId = book.Author.Id;
                int GenreId = book.Genre.Id;
                int StatusId = book.BookStatus.Id;
                book.Author = null;
                book.Genre = null;
                book.BookStatus = null;

                bookContext.Books.Add(book);
                bookContext.SaveChanges();

                book.Author = bookContext.Authors.FirstOrDefault(a => a.Id == AuthorId);
                book.Genre = bookContext.Genres.FirstOrDefault(g => g.Id == GenreId);
                book.BookStatus = bookContext.BookStatuses.FirstOrDefault(s => s.Id == StatusId);

                bookContext.Entry(book).State = EntityState.Modified;
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
