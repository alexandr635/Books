using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Application.Services 
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository { get; set; }
        IFileService FileService { get; set; }

        public BookService(IBookRepository bookRepository, IFileService fileService)
        {
            BookRepository = bookRepository;
            FileService = fileService;
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

        public async Task<List<Book>> GetBooksByFilter(Book book, string role)
        {
            List<Book> books = new List<Book>();
            switch (role)
            {
                case "Администратор":
                    books = await BookRepository.GetBook(book, "");
                    break;
                case "Проверяющий":
                    books = await BookRepository.GetBook(book, "На рассмотрении");
                    books.AddRange(await BookRepository.GetBook(book, "Опубликовано"));
                    books.AddRange(await BookRepository.GetBook(book, "Снято с публикации"));
                    books.OrderBy(b => b.Id);
                    break;
                case "Писатель":
                    books = await BookRepository.GetBook(book, "");
                    break;

                default:
                    books = await BookRepository.GetBook(book, "Опубликовано");
                    break;
            }

            return books;
        }

        public async Task<Book> SetBookData(Book book, int[] tagsId, IFormFileCollection files)
        {
            List<BookToTag> tags = new List<BookToTag>();

            foreach (int tagId in tagsId)
                tags.Add(new BookToTag(book.Id, tagId));

            book.SetBookToTags(tags);

            if (book.BookSeriesId == -1)
                book.SetSeriesId(null);

            var checkBook = await BookRepository.GetNoTrackingBook(book.Id);
            var list = new List<string>()
            {
                "application/octet-stream",
                "text/html",
                "text/plain",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/msword",
                "application/epub+zip"
            };

            if (files.Count() != 0)
            {
                foreach (var file in files)
                {
                    if (file.Name == "newImage" && file.ContentType.Contains("image/"))
                        book.SetImagePath(await FileService.AddBookCover(file));

                    else if (file.Name == "newFile" && list.Contains(file.ContentType))
                        book.SetBookPath(await FileService.AddBookDocument(file));
                }
            }

            if (book.BookPath == null)
                book.SetBookPath(checkBook.BookPath);

            if (book.ImagePath == null)
                book.SetImagePath(checkBook.ImagePath);

            return book;
        }

        async Task DeleteFiles(int id)
        {
            var checkBook = await BookRepository.GetNoTrackingBook(id);

            if (checkBook.ImagePath != null && checkBook.ImagePath != "")
                FileService.DeleteBookCover(checkBook.ImagePath);

            if (checkBook.BookPath != null && checkBook.BookPath != "")
                FileService.DeleteBookDocument(checkBook.BookPath);
        }

        public async Task ChangeBook(Book book)
        {
            const byte draftStatus = 1;
            const byte pendingStatus = 2;
            const byte publishedStatus = 3;
            const byte removePublicationStatus = 4;

            switch (book.BookStatusId)
            {
                case draftStatus:
                case pendingStatus:
                    await DeleteFiles(book.Id);
                    await BookRepository.ChangeBook(book);
                    break;
                case publishedStatus:
                    book.SetConfirm(book.Id);
                    book.SetId(0);
                    book.SetStatusId(pendingStatus);
                    await BookRepository.AddBook(book);
                    break;
                case removePublicationStatus:
                    await DeleteFiles(book.Id);
                    await BookRepository.DeleteBook(book);
                    book.SetId(0);
                    await BookRepository.AddBook(book);
                    break;
            }            
        }

        public async Task AddBook(Book book)
        {
            await BookRepository.AddBook(book);
        }

        public async Task ChangeBookStatus(Book book, string role)
        {
            if (book.ConfirmId != 0 && (role == "Проверяющий" || role == "Администратор"))
            {
                var changeBook = await BookRepository.GetBook(book.ConfirmId);
                var currentBook = await BookRepository.GetBook(book.Id);
                
                changeBook.SetConfirm(0);
                changeBook.SetStatusId(book.BookStatusId);
                changeBook.SetAuthorId(currentBook.AuthorId);
                changeBook.SetAverageRating(currentBook.AverageRating);
                changeBook.SetBookToTags(currentBook.BookToTags);
                changeBook.SetGenreId(currentBook.GenreId);
                changeBook.SetLongDescription(currentBook.DescriptionLong);
                changeBook.SetShortDescription(currentBook.DescriptionShort);
                changeBook.SetTitle(currentBook.Title);
                changeBook.SetSeriesId(currentBook.BookSeriesId);

                if (currentBook.ImagePath != null && currentBook.ImagePath != "")
                {
                    FileService.DeleteBookCover(changeBook.ImagePath);
                    changeBook.SetImagePath(currentBook.ImagePath);
                }
                if (currentBook.BookPath != null && currentBook.BookPath != "")
                {
                    FileService.DeleteBookDocument(changeBook.BookPath);
                    changeBook.SetBookPath(currentBook.BookPath);
                }

                await BookRepository.ChangeBook(changeBook);
                await BookRepository.DeleteBook(currentBook);
            }
            else 
                await BookRepository.ChangeBookStatus(book);
        }
    }
}
