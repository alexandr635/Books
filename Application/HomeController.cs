using System;
using System.Linq;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Application
{
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
    }
}
