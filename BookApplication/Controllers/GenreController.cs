using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            return View(await GenreService.GetGenre());
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("addGenre")]
        public IActionResult AddGenre()
        {
            return View();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("addGenre")]
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

        [Authorize(Roles = "Администратор")]
        [HttpGet("Genre/Change/{Id?}")]
        public async Task<IActionResult> ChangeGenre(int? id)
        {
            if (id == null)
                RedirectToAction();
            try
            {
                return View(await GenreService.GetGenre(id));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("Genre/Change/{Id?}")]
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

        [Authorize(Roles = "Администратор")]
        [HttpGet("Genre/Delete/{Id?}")]
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
