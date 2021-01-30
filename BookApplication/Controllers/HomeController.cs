using Data;
using Microsoft.AspNetCore.Mvc;
using Application;
using System;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public BookContext db;

        public HomeController(BookContext context)
        {
            db = context;

            //change
            DBQuery.InitDB(context);
        }

        public IActionResult Index()
        {
            try
            {
                var listOfBook = DBQuery.GetBook();
                return View(listOfBook);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/Book/{Id?}")]
        [HttpGet]
        public IActionResult Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            try
            {
                Book book = DBQuery.GetBook(id);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
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
            try
            {
                DBQuery.AddBook(book);
                return "Книга добавлена";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }


        [Route("Home/Change/{Id?}")]
        [HttpGet]
        public IActionResult Change(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            try
            {
                Book book = DBQuery.GetBook(id);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/Change/{Id?}")]
        [HttpPost]
        public IActionResult Change(Book book)
        {
            try
            {
                DBQuery.ChangeBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
