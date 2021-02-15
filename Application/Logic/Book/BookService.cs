using Application.DTO;
using Application.Logic;
using Application.Mapping;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository { get; set; }
        IMapper mapper { get; set; }

        public BookService(IBookRepository workWithBook, IMapper mapper)
        {
            BookRepository = workWithBook;
            this.mapper = mapper;
        }

        public async Task<BookDTO> GetBook(int? id)
        {
            Book book = await BookRepository.GetBook(id);
            BookDTO bookDTO = mapper.Map<BookDTO>(book);

            return bookDTO;
        }

        public async Task<HashSet<BookDTO>> GetBook(string pattern)
        {
            var listOfBook = await BookRepository.GetBook(pattern);
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(mapper.Map<BookDTO>(book));

            return list;
        }

        public async Task<HashSet<BookDTO>> GetBook()
        {
            var listOfBook = await BookRepository.GetBook();
            HashSet<BookDTO> list = new HashSet<BookDTO>();

            foreach (Book book in listOfBook)
                list.Add(mapper.Map<BookDTO>(book));

            return list;
        }

        public async Task AddBook(BookDTO book)
        {
            Book newBook = mapper.Map<Book>(book);
            await BookRepository.AddBook(newBook);
        }

        public async Task ChangeBook(BookDTO book)
        {
            Book changeBook = mapper.Map<Book>(book);

            HashSet<Tag> tags = new HashSet<Tag>();
            foreach (var tag in book.TagsDTO)
                tags.Add(mapper.Map<Tag>(tag));

            changeBook.Tags = tags;

            await BookRepository.ChangeBook(changeBook);
        }

        public async Task<HashSet<BookDTO>> GetRatingList(int size)
        {
            var listBook = await BookRepository.GetRatingList(size);
            HashSet<BookDTO> listBookDTO = new HashSet<BookDTO>();

            foreach (Book book in listBook)
                listBookDTO.Add(mapper.Map<BookDTO>(book));

            return listBookDTO;
        }

        public async Task DeleteBook(BookDTO bookDTO)
        {
            Book book = mapper.Map<Book>(bookDTO);
            await BookRepository.DeleteBook(book);
        }

        public async Task<HashSet<BookDTO>> GetBook(BookDTO book)
        {
            HashSet<Book> books = await BookRepository.GetBook(mapper.Map<Book>(book));
            HashSet<BookDTO> bookDTOs = new HashSet<BookDTO>();

            foreach (var entity in books)
                bookDTOs.Add(mapper.Map<BookDTO>(entity));

            return bookDTOs;
        }
    }
}
