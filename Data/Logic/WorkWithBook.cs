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

        public async Task<HashSet<Book>> GetBook()
        {
            var res = Task.Run( () => bookContext.Books.Include("Author").Include("Genre").Include("BookStatus").ToHashSet());
            HashSet<Book> books = await res;
            
            return books;
        }

        public async Task<HashSet<Book>> GetBook(string pattern)
        {
            try
            {
                DateTime date = Convert.ToDateTime(pattern);
                var res = await Task.Run(() => bookContext.Books.Where(b => b.PublishDate == date).ToHashSet());
                return res;
            }
            catch
            {
                var res = await Task.Run(() => bookContext.Books.Where(b => b.Title.Contains(pattern) || b.Author.Name.Contains(pattern) ||
                                                                       b.Author.LastName.Contains(pattern) || b.Author.Patronymic.Contains(pattern) ||
                                                                       b.BookSeries.SeriesName.Contains(pattern) || b.Genre.GenreName.Contains(pattern)).ToHashSet());

                return res;
            }

        }

        public async Task<Book> GetBook(int? id)
        {
            var res = Task.Run( () => bookContext.Books.AsNoTracking().Include("Author").Include("Genre").Include("BookStatus").FirstOrDefault(b => b.Id == id));
            Book book = await res;
            return book;
        }

        public async Task AddBook(Book book)
        {
            await bookContext.Books.AddAsync(book);
            await bookContext.SaveChangesAsync();
        }

        public async Task ChangeBook(Book book)
        {
            bookContext.Update(book);
            await bookContext.SaveChangesAsync();
        }

        public async Task<HashSet<Book>> GetRatingList(int size)
        {
            var result = await Task.Run( () => bookContext.Books.OrderBy(b => b.Reviews.Count).ToHashSet());
            return result;
        }
    }
}
