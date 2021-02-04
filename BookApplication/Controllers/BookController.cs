using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookQuery iDBQuery { get; set; }
        IGenreQuery genreQuery { get; set; }
        IAuthorQuery authorQuery { get; set; }
        IReviewQuery reviewQuery { get; set; }

        public BookController(IBookQuery dBQuery, IGenreQuery genreQuery, IAuthorQuery authorQuery, IReviewQuery reviewQuery)
        {
            iDBQuery = dBQuery;
            this.genreQuery = genreQuery;
            this.authorQuery = authorQuery;
            this.reviewQuery = reviewQuery;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var listOfBook = await iDBQuery.GetBook();
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
                BookDTO book = await iDBQuery.GetBook(id);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/AddReview/{Id?}")]
        [HttpGet]
        public IActionResult AddReview()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/AddReview/{Id?}")]
        [HttpPost]
        public async Task<string> AddReview(ReviewDTO reviewDTO, int? id)
        {
            try
            {
                BookDTO book = await iDBQuery.GetBook(id);
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
            return View(listDTO);
        }

        [Route("AddBook")]
        [HttpPost]
        public async Task<string> AddBook(BookDTO book)
        {
            try
            {
                var genre = Convert.ToInt32(Request.Form["GenreDTO"]);
                var author = Convert.ToInt32(Request.Form["AuthorDTO"]);

                book.GenreDTO = await genreQuery.GetGenre(genre);
                book.AuthorDTO = await authorQuery.GetAuthor(author);

                await iDBQuery.AddBook(book);
                return "Книга добавлена";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("Home/ChangeBook/{Id?}")]
        [HttpGet]
        public async Task<IActionResult> Change(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                BookDTO book = await iDBQuery.GetBook(id);
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
                await iDBQuery.ChangeBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
