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

        public async Task<List<Book>> GetBook()
        {
            return await BookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.BookStatus)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBook(string pattern)
        {
            try
            {
                DateTime date = Convert.ToDateTime(pattern);
                return await BookContext.Books.Where(b => b.PublishDate == date).ToListAsync();
            }
            catch
            {
                return await BookContext.Books.Where(b => b.Title.Contains(pattern) || b.Author.Name.Contains(pattern) ||
                                                    b.Author.LastName.Contains(pattern) || b.Author.Patronymic.Contains(pattern) ||
                                                    b.BookSeries.SeriesName.Contains(pattern) || b.Genre.GenreName.Contains(pattern))
                    .ToListAsync();
            }
        }

        public async Task<Book> GetBook(int? id)
        {
            return await BookContext.Books
                .Include(b => b.BookToTags)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetBook(Book book)
        {
            return await BookContext.Books.Include("Tags").Where(b =>
                (b.Title.Contains(book.Title) ||
                b.BookSeries.SeriesName.Contains(book.Title)) &&
                b.AuthorId == book.AuthorId &&
                b.AverageRating >= book.AverageRating)
                .ToListAsync();
        }

        public async Task AddBook(Book book)
        {
            await BookContext.Books.AddAsync(book);
            await BookContext.SaveChangesAsync();
        }

        public async Task ChangeBook(Book book)
        {
            BookContext.BookToTags.RemoveRange(BookContext.BookToTags.Where(bt => bt.BookId == book.Id));
            BookContext.Books.Update(book);
            await BookContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetRatingList(int size)
        {
            return await BookContext.Books.OrderBy(b => b.Reviews.Count).ToListAsync();
        }

        public async Task DeleteBook(Book book)
        {
            BookContext.Books.Remove(book);
            await BookContext.SaveChangesAsync();
        }
    }
}
