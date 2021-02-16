using Application.DTO;
using Application.Logic;
using AutoMapper;
using Data;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }

        public BookService(IBookRepository workWithBook, IMapper mapper)
        {
            BookRepository = workWithBook;
            Mapper = mapper;
        }

        public async Task<BookDTO> GetBook(int? id)
        {
            Book book = await BookRepository.GetBook(id);
            BookDTO bookDTO = Mapper.Map<BookDTO>(book);

            return bookDTO;
        }

        public async Task<HashSet<BookDTO>> GetBook(string pattern)
        {
            var listOfBook = await BookRepository.GetBook(pattern);
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(Mapper.Map<BookDTO>(book));

            return list;
        }

        public async Task<HashSet<BookDTO>> GetBook()
        {
            var listOfBook = await BookRepository.GetBook();
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(Mapper.Map<BookDTO>(book));

            return list;
        }

        public async Task AddBook(BookDTO book)
        {
            Book newBook = Mapper.Map<Book>(book);
            await BookRepository.AddBook(newBook);
        }

        public async Task ChangeBook(BookDTO book)
        {
            Book changeBook = Mapper.Map<Book>(book);
            await BookRepository.ChangeBook(changeBook);
        }

        public async Task<HashSet<BookDTO>> GetRatingList(int size)
        {
            var listBook = await BookRepository.GetRatingList(size);
            HashSet<BookDTO> listBookDTO = new HashSet<BookDTO>();

            foreach (Book book in listBook)
                listBookDTO.Add(Mapper.Map<BookDTO>(book));

            return listBookDTO;
        }

        public async Task DeleteBook(BookDTO bookDTO)
        {
            Book book = Mapper.Map<Book>(bookDTO);
            await BookRepository.DeleteBook(book);
        }

        public async Task<HashSet<BookDTO>> GetBook(BookDTO book)
        {
            HashSet<Book> books = await BookRepository.GetBook(Mapper.Map<Book>(book));
            HashSet<BookDTO> bookDTOs = new HashSet<BookDTO>();

            foreach (var entity in books)
                bookDTOs.Add(Mapper.Map<BookDTO>(entity));

            return bookDTOs;
        }
    }
}
