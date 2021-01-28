using Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    // new controller
    public class HomeController : Controller
    {
        BookContext db;

        public HomeController(BookContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        [Route("Home/Book/{Id?}")]
        [HttpGet]
        public IActionResult Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View(db.Books.FirstOrDefault(b => b.Id == id));
        }

        [Route("AddBook")]
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [Route("AddBook")]
        [HttpPost]
        public string AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return "Книга добавлена";
        }


        [Route("Home/Change/{Id?}")]
        [HttpGet]
        public IActionResult Change(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View(db.Books.FirstOrDefault(b => b.Id == id));
        }

        [Route("Home/Change/{Id?}")]
        [HttpPost]
        public IActionResult Change(Book book)
        {
            Book currentBook = db.Books.FirstOrDefault(b => b.Id == book.Id);
            currentBook.Title = book.Title;
            currentBook.DescriptionLong = book.DescriptionLong;
            currentBook.DescriptionShort = book.DescriptionShort;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
