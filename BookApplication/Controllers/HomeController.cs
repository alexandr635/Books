using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.Id = id;
            return View(db.Books.FirstOrDefault(b => b.Id == id));
        }
    }
}
