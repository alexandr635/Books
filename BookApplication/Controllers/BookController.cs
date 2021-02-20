using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Application.Pagination;

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

        static List<BookDTO> bookForPagination { get; set; }

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

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                return View(await BookService.GetBook());
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
                return View(await BookService.GetBook(id));
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
            return View(await BookService.GetBook(pattern));
        }

        [Route("AddBook")]
        [HttpGet]
        [Authorize(Roles = "Писатель, Администратор")]
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
        [Authorize(Roles = "Администратор")]
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
        [Authorize(Roles = "Писатель, Администратор")]
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
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> Change(BookDTO book, int[] tagsId)
        {
            try
            {
                List<BookToTagDTO> tags = new List<BookToTagDTO>();

                foreach (int tagId in tagsId)
                    tags.Add(new BookToTagDTO(book.Id, tagId));


                book.BookToTagsDTO = tags;
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
        [Authorize(Roles = "Администратор")]
        public async Task<string> DeleteBook(BookDTO bookDTO)
        {
            await BookService.DeleteBook(bookDTO);

            return "Книга удалена";
        }

        [Route("Home/Book/Filters")]
        [HttpGet]
        public async Task<IActionResult> FilterBook()
        {
            ListDTO listDTO = new ListDTO()
            {
                AuthorDTO = await AuthorService.GetAuthor(),
                TagDTO = await TagService.GetTag()
            };

            return View(listDTO);
        }

        [Route("Home/Book/Filters")]
        [HttpPost]
        public async Task<IActionResult> FilterBookResult(BookDTO bookDTO, int[] tagsId)
        {
            List<BookToTagDTO> bookToTags = new List<BookToTagDTO>();

            foreach (int tagId in tagsId)
                bookToTags.Add(new BookToTagDTO(bookDTO.Id, tagId));

            bookDTO.BookToTagsDTO = bookToTags;
            bookForPagination = await BookService.GetBook(bookDTO);

            return RedirectPermanent("~/Home/BookResult");            
        }

        [Route("Home/BookResult")]
        public IActionResult FilterResult(int page = 1)
        {
            int pageSize = 1;
            int count = bookForPagination.Count();
            List<BookDTO> items = bookForPagination.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Books = items
            };
            return View(viewModel);
        }
    }
}
