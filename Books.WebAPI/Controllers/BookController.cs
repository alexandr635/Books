using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookService BookService { get; set; }
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }
        IAuthorRepository AuthorRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IBookStatusService BookStatusService { get; set; }
        ITagRepository TagRepository { get; set; }
        IBookStatusRepository BookStatusRepository { get; set; }
        IBookSeriesRepository BookSeriesRepository { get; set; }

        public BookController(IBookService bookService, IMapper mapper, IBookRepository bookRepository,
                              IAuthorRepository authorRepository,
                              IGenreRepository genreRepository, IUserRepository userRepository,
                              IBookStatusService bookStatusService, ITagRepository tagRepository,
                              IBookStatusRepository bookStatusRepository, IBookSeriesRepository bookSeriesRepository)
        {
            BookService = bookService;
            Mapper = mapper;
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            GenreRepository = genreRepository;
            UserRepository = userRepository;
            BookStatusService = bookStatusService;
            TagRepository = tagRepository;
            BookStatusRepository = bookStatusRepository;
            BookSeriesRepository = bookSeriesRepository;
        }

        public async Task<IActionResult> Index(string title = null, double rating = 0, int author = -1, int genre = -1, int page = 1)
        {
            try
            {
                string role;
                string name;
                try
                {
                    role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                    name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                }
                catch
                {
                    role = "Читатель";
                    name = "";
                }

                const int pageSize = 3;
                var book = new Book(title, author, genre, rating);
                var books = await BookService.GetBooksByFilter(book, role);
                User user;
                try
                {
                    user = await UserRepository.GetUserWithBooks(name);
                }
                catch
                {
                    user = null;
                }

                var filter = new FilterBookDTO()
                {
                    Books = Mapper.Map<List<BookDTO>>(books.Skip((page - 1) * pageSize).Take(pageSize)),
                    Authors = Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor()),
                    Genres = Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre()),
                    PageCount = (int)Math.Ceiling((decimal)books.Count / pageSize),
                    Page = page,
                    AuthorId = author,
                    GenreId = genre,
                    AverageRating = rating,
                    Title = title,
                    User = Mapper.Map<UserDTO>(user)
                };

                return View(filter);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Home/Book/{Id?}")]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                var toDTO = Mapper.Map<BookDTO>(await BookRepository.GetBook(id));
                ViewData["Name"] = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                return View(toDTO);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("AddBook")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> AddBook()
        {
            try
            {
                ListDTO list = new()
                {
                    GenreDTO = Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre()),
                    AuthorDTO = Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor()),
                    BookStatusDTO = Mapper.Map<List<BookStatusDTO>>(await BookStatusRepository.GetStatus()),
                    BookSeriesDTO = Mapper.Map<List<BookSeriesDTO>>(await BookSeriesRepository.GetSeries()),
                    TagDTO = Mapper.Map<List<TagDTO>>(await TagRepository.GetTag())
                };

                return View(list);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("AddBook")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> AddBook(BookDTO book, int[] tagsId)
        {
            try
            {
                var currentBook = await BookService.SetBookData(Mapper.Map<Book>(book), tagsId, Request.Form.Files);
                await BookService.AddBook(currentBook);
                return RedirectToAction("Index", "Book");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Home/ChangeBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> ChangeBook(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                ListDTO list = new()
                {
                    GenreDTO = Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre()),
                    AuthorDTO = Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor()),
                    BookStatusDTO = Mapper.Map<List<BookStatusDTO>>(await BookStatusRepository.GetStatus()),
                    BookSeriesDTO = Mapper.Map<List<BookSeriesDTO>>(await BookSeriesRepository.GetSeries()),
                    TagDTO = Mapper.Map<List<TagDTO>>(await TagRepository.GetTag()),
                    BookDTO = Mapper.Map<BookDTO>(await BookRepository.GetBook(id))
                };

                return View(list);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Home/ChangeBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> Change(BookDTO book, int[] tagsId)
        {
            try
            {
                var currentBook = await BookService.SetBookData(Mapper.Map<Book>(book), tagsId, Request.Form.Files);
                await BookService.ChangeBook(currentBook);
                return RedirectToAction("Index");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Home/DeleteBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> DeleteBook(BookDTO bookDTO)
        {
            await BookRepository.DeleteBook(Mapper.Map<Book>(bookDTO));
            return RedirectToAction("Index", "Book");
        }

        [HttpGet("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
                RedirectToAction("Index", "Book");

            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            ListDTO list = new()
            {
                BookDTO = Mapper.Map<BookDTO>(await BookRepository.GetBook(id)),
                BookStatusDTO = Mapper.Map<List<BookStatusDTO>>(await BookStatusService.GetStatusByRole(role))
            };

            return View(list);
        }

        [HttpPost("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(BookDTO book)
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            await BookService.ChangeBookStatus(Mapper.Map<Book>(book), role);
            return RedirectToAction("Index");
        }

        [HttpGet("Home/ReadBook/{Id?}")]
        public async Task ReadBook(int? id)
        {
            if (id == null)
                Response.StatusCode = 500;
            else
            {
                var buffer = await BookService.ReadBook((int)id);
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.Headers.Add("content-length", buffer.Length.ToString());
                    await Response.BodyWriter.WriteAsync(buffer);
                }
                else
                    Response.StatusCode = 500;
            }
        }
    }
}
