using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IDBQuery iDBQuery;

        public BookController(IDBQuery dBQuery)
        {
            iDBQuery = dBQuery;
        }

        public IActionResult Index()
        {
            try
            {
                var listOfBook = iDBQuery.GetBook();
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
                BookDTO book = iDBQuery.GetBook(id);
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
        public string AddBook(BookDTO book)
        {
            try
            {
                iDBQuery.AddBook(book);
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
                BookDTO book = iDBQuery.GetBook(id);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/Change/{Id?}")]
        [HttpPost]
        public IActionResult Change(BookDTO book)
        {
            try
            {
                iDBQuery.ChangeBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
