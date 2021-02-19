using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class RatingController : Controller
    {
        IBookService BookService { get; set; }

        public RatingController(IBookService BookService)
        {
            this.BookService = BookService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await BookService.GetRatingList(100));
        }
    }
}
