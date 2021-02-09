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
        IGenreService GenreService { get; set; }

        public GenreController(IGenreService GenreService)
        {
            this.GenreService = GenreService;
        }

        public async Task<IActionResult> Index()
        {
            HashSet<GenreDTO> listOfGenres = await GenreService.GetGenre();
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
                await GenreService.AddGenre(genreDTO);
                return "Жанр добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("Genre/Change/{Id?}")]
        public async Task<IActionResult> ChangeGenre(int? id)
        {
            if (id == null)
                RedirectToAction();
            try
            {
                var result = await GenreService.GetGenre(id);
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("Genre/Change/{Id?}")]
        public async Task<string> ChangeGenre(GenreDTO genreDTO)
        {
            try
            {
                await GenreService.ChangeGenre(genreDTO);
                return "Жанр изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("Genre/Delete/{Id?}")]
        public async Task<string> DeleteGenre(GenreDTO genreDTO, int? id)
        {
            if (id == null)
                return "fuck you";
            else
            {
                await GenreService.DeleteGenre(genreDTO);
                return "Жанр удален!";
            }
        }
    }
}
