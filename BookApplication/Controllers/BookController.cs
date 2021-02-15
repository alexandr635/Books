using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookService BookService { get; set; }
        IGenreService GenreService { get; set; }
        IAuthorService AuthorService { get; set; }
        IStatusService StatusService { get; set; }
        ISeriesService SeriesService { get; set; }
        ITagService TagService { get; set; }

        public BookController(IBookService BookService, IGenreService GenreService, 
                              IAuthorService AuthorService, IStatusService StatusService, 
                              ISeriesService SeriesService, ITagService TagService)
        {
            this.BookService = BookService;
            this.GenreService = GenreService;
            this.AuthorService = AuthorService;
            this.StatusService = StatusService;
            this.SeriesService = SeriesService;
            this.TagService = TagService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var listOfBook = await BookService.GetBook();
                return View(listOfBook);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/Book/{Id?}")]
        [HttpGet]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                BookDTO book = await BookService.GetBook(id);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("FindBook")]
        [HttpGet]
        public async Task<IActionResult> FindBook(string pattern)
        {
            var bookDTO = await BookService.GetBook(pattern);
            return View(bookDTO);
        }

        [Route("AddBook")]
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            ListDTO listDTO = new ListDTO
            {
                GenreDTO = await GenreService.GetGenre(),
                AuthorDTO = await AuthorService.GetAuthor(),
                BookStatusDTO = await StatusService.GetStatus(),
                BookSeriesDTO = await SeriesService.GetSeries()
            };
            return View(listDTO);
        }

        [Route("AddBook")]
        [HttpPost]
        public async Task<string> AddBook(BookDTO book)
        {
            try
            {
                await BookService.AddBook(book);
                return "Книга добавлена";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("Home/ChangeBook/{Id?}")]
        [HttpGet]
        public async Task<IActionResult> ChangeBook(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                ListDTO listDTO = new ListDTO
                {
                    GenreDTO = await GenreService.GetGenre(),
                    AuthorDTO = await AuthorService.GetAuthor(),
                    BookStatusDTO = await StatusService.GetStatus(),
                    BookSeriesDTO = await SeriesService.GetSeries(),
                    TagDTO = await TagService.GetTag(),
                    BookDTO = await BookService.GetBook(id)
                };
                return View(listDTO);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/ChangeBook/{Id?}")]
        [HttpPost]
        public async Task<IActionResult> Change(BookDTO book, int[] tagsId)
        {
            try
            {
                HashSet<TagDTO> tags = new HashSet<TagDTO>();

                foreach (int tagId in tagsId)
                    tags.Add(await TagService.GetTag(tagId));

                book.TagsDTO = tags;

                await BookService.ChangeBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/DeleteBook/{Id?}")]
        [HttpGet]
        public async Task<string> DeleteBook(BookDTO bookDTO)
        {
            await BookService.DeleteBook(bookDTO);

            return "Книга удалена";
        }

        [Route("Home/Book/Filters")]
        [HttpGet]
        public async Task<IActionResult> FilterBook()
        {
            ListDTO listDTO = new ListDTO();
            listDTO.AuthorDTO = await AuthorService.GetAuthor();
            listDTO.TagDTO = await TagService.GetTag();

            return View(listDTO);
        }

        [Route("Home/Book/Filters")]
        [HttpPost]
        public async Task<IActionResult> FilterBookResult(BookDTO bookDTO, int[] tagsId)
        {
            HashSet<TagDTO> tags = new HashSet<TagDTO>();

            foreach (int tagId in tagsId)
                tags.Add(await TagService.GetTag(tagId));

            bookDTO.TagsDTO = tags;
            HashSet<BookDTO> books = await BookService.GetBook(bookDTO); 

            return View(books);
        }
    }
}
