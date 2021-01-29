using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public static class DBQuery
    {
        static BookContext db { set; get; }

        public static void InitDB(BookContext context)
        {
            db = context;
        }

        public static Book GetBook(int? id)
        {
            try
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);
                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Book> GetListOfBook()
        {
            try
            {
                var listOfBook = db.Books.ToList();
                return listOfBook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddBook(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ChangeBook(Book book)
        {
            try
            {
                Book currentBook = db.Books.FirstOrDefault(b => b.Id == book.Id);
                currentBook.Title = book.Title;
                currentBook.DescriptionLong = book.DescriptionLong;
                currentBook.DescriptionShort = book.DescriptionShort;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
