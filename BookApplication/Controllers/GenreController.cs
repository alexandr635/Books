using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class GenreController : Controller
    {
        IGenreQuery genreQuery { get; set; }

        public GenreController(IGenreQuery genreQuery)
        {
            this.genreQuery = genreQuery;
        }

        public async Task<IActionResult> Index()
        {
            List<GenreDTO> listOfGenres = await genreQuery.GetGenre();
            return View(listOfGenres);
        }

        [HttpGet]
        [Route("addGenre")]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        [Route("addGenre")]
        public async Task<string> AddGenre(GenreDTO genreDTO)
        {
            try
            {
                await genreQuery.AddGenre(genreDTO);
                return "Жанр добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("Change/{Id?}")]
        public async Task<IActionResult> ChangeGenre(int? id)
        {
            if (id == null)
                RedirectToAction();
            try
            {
                var result = await genreQuery.GetGenre(id);
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("Change/{Id?}")]
        public async Task<string> ChangeGenre(GenreDTO genreDTO)
        {
            try
            {
                await genreQuery.ChangeGenre(genreDTO);
                return "Жанр изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
