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
            return Mapper.Map<BookDTO>(await BookRepository.GetBook(id));
        }

        public async Task<List<BookDTO>> GetBook(string pattern)
        {
            return Mapper.Map<List<BookDTO>>(await BookRepository.GetBook(pattern));
        }

        public async Task<List<BookDTO>> GetBook()
        {
            return Mapper.Map<List<BookDTO>>(await BookRepository.GetBook());
        }

        public async Task AddBook(BookDTO book)
        {
            await BookRepository.AddBook(Mapper.Map<Book>(book));
        }

        public async Task ChangeBook(BookDTO book)
        {
            await BookRepository.ChangeBook(Mapper.Map<Book>(book));
        }

        public async Task<List<BookDTO>> GetRatingList(int size)
        {
            return Mapper.Map<List<BookDTO>>(await BookRepository.GetRatingList(size));
        }

        public async Task DeleteBook(BookDTO bookDTO)
        {
            await BookRepository.DeleteBook(Mapper.Map<Book>(bookDTO));
        }

        public async Task<List<BookDTO>> GetBook(BookDTO book)
        {
            List<Book> books = await BookRepository.GetBook(Mapper.Map<Book>(book));

            return Mapper.Map<List<BookDTO>>(books);
        }
    }
}
