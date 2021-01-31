using System.Collections.Generic;
using System.Linq;

namespace Data.Logic
{
    public class WorkWithBook : IWorkWithBook
    {
        BookContext bookContext;

        public WorkWithBook(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public List<Book> GetBook()
        {
            var books = bookContext.Books.ToList();
            return books;
        }

        public Book GetBook(int? id)
        {
            var book = bookContext.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public void AddBook(Book book)
        {
            bookContext.Books.Add(book);
            bookContext.SaveChanges();
        }

        public void ChangeBook(Book book)
        {
            Book currentBook = bookContext.Books.FirstOrDefault(b => b.Id == book.Id);
            currentBook.Title = book.Title;
            currentBook.DescriptionLong = book.DescriptionLong;
            currentBook.DescriptionShort = book.DescriptionShort;

            bookContext.SaveChanges();
        }
    }
}
