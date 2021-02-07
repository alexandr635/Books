using Application.DTO;
using Application.Logic;
using Data;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class BookQuery : IBookQuery
    {
        IWorkWithBook iWorkWithBook;

        public BookQuery(IWorkWithBook workWithBook)
        {
            iWorkWithBook = workWithBook;
        }

        public async Task<BookDTO> GetBook(int? id)
        {
            Book book = await iWorkWithBook.GetBook(id);
            BookDTO bookDTO = ConvertTo.BookDTO(book);
            return bookDTO;
        }

        public async Task<HashSet<BookDTO>> GetBook(string pattern)
        {
            var listOfBook = await iWorkWithBook.GetBook(pattern);
            HashSet<BookDTO> list = new HashSet<BookDTO>();
            foreach (Book book in listOfBook)
                list.Add(ConvertTo.BookDTO(book));

            return list;
        }

        public async Task<HashSet<BookDTO>> GetBook()
        {
            var listOfBook = await iWorkWithBook.GetBook();
            HashSet<BookDTO> list = new HashSet<BookDTO>();
            foreach (Book book in listOfBook)
                list.Add(ConvertTo.BookDTO(book));

            return list;
        }

        public async Task AddBook(BookDTO book)
        {
            Book newBook = ConvertTo.Book(book);
            await iWorkWithBook.AddBook(newBook);
        }

        public async Task ChangeBook(BookDTO book)
        {
            Book changeBook = ConvertTo.Book(book);
            await iWorkWithBook.ChangeBook(changeBook);
        }

        public async Task<HashSet<BookDTO>> GetRatingList(int size)
        {
            var listBook = await iWorkWithBook.GetRatingList(size);
            HashSet<BookDTO> listBookDTO = new HashSet<BookDTO>();
            foreach (Book book in listBook)
                listBookDTO.Add(ConvertTo.BookDTO(book));

            return listBookDTO;
        }
    }
}
