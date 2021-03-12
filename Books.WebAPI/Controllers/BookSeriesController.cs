using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class BookSeriesController : Controller
    {
        IBookSeriesRepository BookSeriesRepository { get; set; }
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }

        public BookSeriesController(IBookSeriesRepository bookSeriesRepository, IBookRepository bookRepository,
                                    IMapper mapper)
        {
            BookSeriesRepository = bookSeriesRepository;
            BookRepository = bookRepository;
            Mapper = mapper;
        }

        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<BookSeriesDTO>>(await BookSeriesRepository.GetSeries());
            return View(listDTO);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("BookSeries/AddBookSeries")]
        public async Task<IActionResult> AddBookSeries()
        {
            var dto = Mapper.Map<List<BookDTO>>(await BookRepository.GetBook());
            return View(dto);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("BookSeries/AddBookSeries")]
        public async Task<IActionResult> AddBookSeries(BookSeriesDTO bookSeriesDTO)
        {
            await BookSeriesRepository.AddSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
            return RedirectToAction("Index", "BookSeries");
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("BookSeries/ChangeSeries/{Id?}")]
        public async Task<IActionResult> Change(int? id)
        {
            if (id == null)
                RedirectToAction();
            try
            {
                var dto = Mapper.Map<BookSeriesDTO>(await BookSeriesRepository.GetSeries((int)id));
                return View(dto);
            }
            catch
            {
                return StatusCode(403);
            }
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("BookSeries/ChangeSeries/{Id?}")]
        public async Task<IActionResult> Change(BookSeriesDTO series)
        {
            try
            {
                await BookSeriesRepository.ChangeSeries(Mapper.Map<BookSeries>(series));
                return RedirectToAction("Index", "BookSeries");
            }
            catch
            {
                return StatusCode(403);
            }
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("BookSeries/DeleteSeries/{id?}")]
        public async Task<IActionResult> DeleteBookSeries(BookSeriesDTO bookSeriesDTO, int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Account");
            else
            {
                await BookSeriesRepository.DeleteSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
                return RedirectToAction("Index", "BookSeries");
            }
        }
    }
}
