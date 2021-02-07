using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class RatingController : Controller
    {
        IBookQuery bookQuery { get; set; }

        public RatingController(IBookQuery bookQuery)
        {
            this.bookQuery = bookQuery;
        }

        public async Task<IActionResult> Index()
        {
            HashSet<BookDTO> listBook = await bookQuery.GetRatingList(100);
            return View(listBook);
        }
    }
}
