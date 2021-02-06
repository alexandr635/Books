using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookQuery bookQuery { get; set; }
        IGenreQuery genreQuery { get; set; }
        IAuthorQuery authorQuery { get; set; }
        IReviewQuery reviewQuery { get; set; }
        IStatusQuery statusQuery { get; set; }

        public BookController(IBookQuery bookQuery, IGenreQuery genreQuery, 
                              IAuthorQuery authorQuery, IReviewQuery reviewQuery, IStatusQuery statusQuery)
        {
            this.bookQuery = bookQuery;
            this.genreQuery = genreQuery;
            this.authorQuery = authorQuery;
            this.reviewQuery = reviewQuery;
            this.statusQuery = statusQuery;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var listOfBook = await bookQuery.GetBook();
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
                BookDTO book = await bookQuery.GetBook(id);
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
                await reviewQuery.AddReview(reviewDTO);
                return "Отзыв добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("AddBook")]
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            ListDTO listDTO = new ListDTO();
            listDTO.GenreDTO = await genreQuery.GetGenre();
            listDTO.AuthorDTO = await authorQuery.GetAuthor();
            listDTO.BookStatusDTO = await statusQuery.GetStatus();
            return View(listDTO);
        }

        [Route("AddBook")]
        [HttpPost]
        public async Task<string> AddBook(BookDTO book)
        {
            try
            {
                await bookQuery.AddBook(book);
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
                BookDTO book = await bookQuery.GetBook(id);
                return View(book);
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
                await bookQuery.ChangeBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
