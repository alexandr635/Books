using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class BookRepository : IBookRepository
    {
        BookContext BookContext { get; set; }

        public BookRepository(BookContext BookContext)
        {
            this.BookContext = BookContext;
        }

        public async Task<HashSet<Book>> GetBook()
        {
            var res = Task.Run( () => BookContext.Books.Include("Author").Include("Genre").Include("BookStatus").ToHashSet());
            HashSet<Book> books = await res;
            
            return books;
        }

        public async Task<HashSet<Book>> GetBook(string pattern)
        {
            try
            {
                DateTime date = Convert.ToDateTime(pattern);
                var res = await Task.Run(() => BookContext.Books.Where(b => b.PublishDate == date).ToHashSet());
                return res;
            }
            catch
            {
                var res = await Task.Run(() => BookContext.Books.Where(b => b.Title.Contains(pattern) || b.Author.Name.Contains(pattern) ||
                                                                       b.Author.LastName.Contains(pattern) || b.Author.Patronymic.Contains(pattern) ||
                                                                       b.BookSeries.SeriesName.Contains(pattern) || b.Genre.GenreName.Contains(pattern)).ToHashSet());

                return res;
            }
        }

        public async Task<Book> GetBook(int? id)
        {
            var res = Task.Run( () => BookContext.Books.Include("Author").Include("Genre").Include("BookStatus").Include("Tags").FirstOrDefault(b => b.Id == id));
            Book book = await res;

            return book;
        }

        public async Task<HashSet<Book>> GetBook(Book book)
        {
            var books = await Task.Run( () => BookContext.Books.Where(b => 
                b.Title == book.Title ||
                b.BookSeries.SeriesName == book.Title ||
                b.Author.Id == book.AuthorId ||
                b.AverageRating >= book.AverageRating ||
                b.Tags.Intersect(book.Tags).Count() > 0).ToHashSet());

            return books;
        }

        public async Task AddBook(Book book)
        {
            await BookContext.Books.AddAsync(book);
            await BookContext.SaveChangesAsync();
        }

        public async Task ChangeBook(Book book)
        {
            BookContext.Books.Update(book);            
            await BookContext.SaveChangesAsync();
        }

        public async Task<HashSet<Book>> GetRatingList(int size)
        {
            var result = await Task.Run( () => BookContext.Books.OrderBy(b => b.Reviews.Count).ToHashSet());

            return result;
        }

        public async Task DeleteBook(Book book)
        {
            BookContext.Books.Remove(book);
            await BookContext.SaveChangesAsync();
        }
    }
}
