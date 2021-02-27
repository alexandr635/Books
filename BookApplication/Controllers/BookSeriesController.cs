using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BookSeriesController : Controller
    {
        ISeriesService SeriesService { get; set; }
        IBookService BookService { get; set; }

        public BookSeriesController(ISeriesService SeriesService, IBookService BookService)
        {
            this.SeriesService = SeriesService;
            this.BookService = BookService;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            return View(await SeriesService.GetSeries());
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("AddBookSeries")]
        public async Task<IActionResult> AddBookSeries()
        {
            return View(await BookService.GetBook());
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("AddBookSeries")]
        public async Task<string> AddBookSeries(BookSeriesDTO bookSeriesDTO)
        {
            await SeriesService.AddSeries(bookSeriesDTO);
            return "Серия добавлена!";
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("BookSeries/DeleteSeries/{id?}")]
        public async Task<string> AddBookSeries(BookSeriesDTO bookSeriesDTO, int? id)
        {
            if (id == null)
                return "потеряйся";
            else
            {
                await SeriesService.DeleteSeries(bookSeriesDTO);
                return "Серия удалена";
            }
        }
    }
}
