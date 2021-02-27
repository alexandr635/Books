using Application.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            return View(await BookService.GetRatingList(100));
        }
    }
}
