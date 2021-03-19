using Books.Domain.Interfaces;
using System.Collections.Generic;
using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Books.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        ApplicationContext BookContext { get; set; }

        public BookRepository(ApplicationContext BookContext)
        {
            this.BookContext = BookContext;
        }

        public async Task<List<Book>> GetBook()
        {
            var res = await BookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.BookStatus)
                .ToListAsync();
            return res;
        }

        public async Task<List<Book>> GetBook(string pattern)
        {
            return await BookContext.Books
                .Include(b => b.Author)
                .Where(b => b.BookStatus.StatusName == pattern)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBook(BookStatus status)
        {
            return await BookContext.Books
                .Where(b => b.BookStatus.StatusName == status.StatusName)
                .ToListAsync();
        }

        public async Task<Book> GetBook(int? id)
        {
            var res = await BookContext.Books
                .Include(b => b.BookToTags)
                .Include(b => b.Author)
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);

            foreach(var review in res.Reviews)
                review.SetUser(await BookContext.Users.FirstOrDefaultAsync(u => u.Id == review.UserId));

            return res;
        }

        public async Task<List<Book>> GetBook(Book book)
        {
            var books = await BookContext.Books
                .Include(b => b.BookToTags)
                .Where(b =>
                    (b.Title.Contains(book.Title) ||
                    b.BookSeries.SeriesName.Contains(book.Title)) &&
                    b.AuthorId == book.AuthorId &&
                    b.AverageRating >= book.AverageRating &&
                    b.BookToTags.Any(tag => book.BookToTags.Any()))
                .ToListAsync();

            return books;
        }

        public async Task<List<Book>> GetBook(Book book, string status)
        {
            List<Book> books;
            if (book.Title != null)
                books = await BookContext.Books
                .Include(b => b.Author)
                .Include(b => b.BookStatus)
                .Where(b => b.Title.Contains(book.Title) &&
                            b.BookStatus.StatusName.Contains(status) &&
                            b.AverageRating >= book.AverageRating)
                .ToListAsync();
            else
                books = await BookContext.Books
                .Include(b => b.Author)
                .Include(b => b.BookStatus)
                .Where(b => b.BookStatus.StatusName.Contains(status) &&
                            b.AverageRating >= book.AverageRating)
                .ToListAsync();

            if (book.AuthorId != -1)
            {
                books = books.Where(b => b.AuthorId == book.AuthorId).ToList();
            }

            if (book.GenreId != -1)
            {
                books = books.Where(b => b.GenreId == book.GenreId).ToList();
            }

            return books;
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
            BookContext.Entry(book).Property(b => b.Image).IsModified = false;
            await BookContext.SaveChangesAsync();
        }

        public async Task ChangeBookStatus(Book book)
        {
            BookContext.Entry(book).Property(b => b.BookStatusId).IsModified = true;
            BookContext.Entry(book).Property(b => b.ConfirmId).IsModified = true;
            await BookContext.SaveChangesAsync();
        }

        public async Task ChangeBookImage(Book book)
        {
            BookContext.Entry(book).Property(b => b.Image).IsModified = true;
            await BookContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetRatingList(int size)
        {
            return await BookContext.Books
                .OrderBy(b => b.Reviews.Count)
                .ToListAsync();
        }

        public async Task DeleteBook(Book book)
        {
            BookContext.Books.Remove(book);
            await BookContext.SaveChangesAsync();
        }
    }
}
