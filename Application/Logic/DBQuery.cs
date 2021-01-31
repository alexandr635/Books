using Application.DTO;
using Application.Logic;
using Data;
using Data.Logic;
using System.Collections.Generic;

namespace Application
{
    public class DBQuery : IDBQuery
    {
        IWorkWithBook iWorkWithBook;

        public DBQuery(IWorkWithBook workWithBook)
        {
            iWorkWithBook = workWithBook;
        }

        public BookDTO GetBook(int? id)
        {
            var book = iWorkWithBook.GetBook(id);
            BookDTO bookDTO = ConvertTo.BookDTO(book);
            return bookDTO;
        }

        public List<BookDTO> GetBook()
        {
            var listOfBook = iWorkWithBook.GetBook();
            List<BookDTO> list = new List<BookDTO>();
            foreach (Book book in listOfBook)
                list.Add(ConvertTo.BookDTO(book));

            return list;
        }

        public void AddBook(BookDTO book)
        {
            Book newBook = ConvertTo.Book(book);
            iWorkWithBook.AddBook(newBook);
        }

        public void ChangeBook(BookDTO book)
        {
            Book changeBook = ConvertTo.Book(book);
            iWorkWithBook.ChangeBook(changeBook);
        }
    }
}
