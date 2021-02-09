using Application.DTO;
using Application.Logic;
using Application.Mapping;
using Data;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository { set; get; }

        public BookService(IBookRepository workWithBook)
        {
            BookRepository = workWithBook;
        }

        public async Task<BookDTO> GetBook(int? id)
        {
            Book book = await BookRepository.GetBook(id);
            BookDTO bookDTO = BookMap.BookDTO(book);

            return bookDTO;
        }

        public async Task<HashSet<BookDTO>> GetBook(string pattern)
        {
            var listOfBook = await BookRepository.GetBook(pattern);
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(BookMap.BookDTO(book));

            return list;
        }

        public async Task<HashSet<BookDTO>> GetBook()
        {
            var listOfBook = await BookRepository.GetBook();
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(BookMap.BookDTO(book));

            return list;
        }

        public async Task AddBook(BookDTO book)
        {
            Book newBook = BookMap.Book(book);
            await BookRepository.AddBook(newBook);
        }

        public async Task ChangeBook(BookDTO book)
        {
            Book changeBook = BookMap.Book(book);
            await BookRepository.ChangeBook(changeBook);
        }

        public async Task<HashSet<BookDTO>> GetRatingList(int size)
        {
            var listBook = await BookRepository.GetRatingList(size);
            HashSet<BookDTO> listBookDTO = new HashSet<BookDTO>();

            foreach (Book book in listBook)
                listBookDTO.Add(BookMap.BookDTO(book));

            return listBookDTO;
        }

        public async Task DeleteBook(BookDTO bookDTO)
        {
            Book book = BookMap.Book(bookDTO);
            await BookRepository.DeleteBook(book);
        }
    }
}
