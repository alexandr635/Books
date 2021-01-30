using Application.DTO;
using Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public static class DBQuery
    {
        static BookContext db { get; set; }

        public static void InitDB(BookContext context)
        {
            db = context;
        }

        public static Book GetBook(int? id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public static List<BookDTO> GetBook()
        {
            var listOfBook = db.Books.ToList();

            List<BookDTO> list = new List<BookDTO>();
            foreach (Book book in listOfBook)
            {
                list.Add(new BookDTO { 
                    Id = book.Id,
                    Title = book.Title,
                    DescriptionLong = book.DescriptionLong,
                    DescriptionShort = book.DescriptionShort
                });
            }
            return list;
        }

        public static void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public static void ChangeBook(Book book)
        {
            Book currentBook = db.Books.FirstOrDefault(b => b.Id == book.Id);
            currentBook.Title = book.Title;
            currentBook.DescriptionLong = book.DescriptionLong;
            currentBook.DescriptionShort = book.DescriptionShort;
            db.SaveChanges();
        }
    }
}
