using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BookSeriesController : Controller
    {
        ISeriesQuery seriesQuery { get; set; }
        IBookQuery bookQuery { get; set; }

        public BookSeriesController(ISeriesQuery seriesQuery, IBookQuery bookQuery)
        {
            this.seriesQuery = seriesQuery;
            this.bookQuery = bookQuery;
        }


        public async Task<IActionResult> Index()
        {
            var result = await seriesQuery.GetSeries();
            return View(result);
        }

        [HttpGet]
        [Route("/AddBookSeries/{Id?}")]
        public async Task<IActionResult> AddBookSeries()
        {
            var books = await bookQuery.GetBook();
            return View(books);
        }
    }
}
