using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookService BookService { get; set; }
        IGenreService GenreService { get; set; }
        IAuthorService AuthorService { get; set; }
        IReviewService ReviewService { get; set; }
        IStatusService StatusService { get; set; }
        ISeriesService SeriesService { get; set; }

        public BookController(IBookService BookService, IGenreService GenreService, 
                              IAuthorService AuthorService, IReviewService ReviewService, 
                              IStatusService StatusService, ISeriesService SeriesService)
        {
            this.BookService = BookService;
            this.GenreService = GenreService;
            this.AuthorService = AuthorService;
            this.ReviewService = ReviewService;
            this.StatusService = StatusService;
            this.SeriesService = SeriesService;
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

        [Route("Home/AddReview/{Id?}")]
        [HttpGet]
        public IActionResult AddReview(int? id)
        {
            try
            {
                return View(id);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/AddReview/{Id?}")]
        [HttpPost]
        public async Task<string> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                await ReviewService.AddReview(reviewDTO);
                return "Отзыв добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
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
        public async Task<IActionResult> Change(BookDTO book)
        {
            try
            {
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
    }
}
