using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository { get; set; }

        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooksByRole(string role)
        {
            List<Book> books = new List<Book>();
            switch (role)
            {
                case "Администратор":
                    books = await BookRepository.GetBook();
                    break;
                case "Проверяющий":
                    books = await BookRepository.GetBook("На рассмотрении");
                    books.AddRange(await BookRepository.GetBook("Опубликовано"));
                    books.AddRange(await BookRepository.GetBook("Снято с публикации"));
                    books.OrderBy(b => b.Id);
                    break;
                case "Писатель":
                    books = await BookRepository.GetBook();
                    break;

                default:
                    books = await BookRepository.GetBook("Опубликовано");
                    break;
            }

            return books;
        }

        public async Task ChangeBook(Book book, int[] tagsId)
        {
            List<BookToTag> tags = new List<BookToTag>();

            foreach (int tagId in tagsId)
                tags.Add(new BookToTag(book.Id, tagId));

            book.SetBookToTags(tags);
            await BookRepository.ChangeBook(book);
        }
        
        public async Task AddBookImage(int id, IFormFile file)
        {
            Book book = new Book(id);

            using (var target = new MemoryStream())
            {
                await file.CopyToAsync(target);
                book.SetImage(target.ToArray());
            }
            
            await BookRepository.ChangeBookImage(book);
        }
    }
}
