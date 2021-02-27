using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService AuthorService { get; set; }

        public AuthorController(IAuthorService AuthorService)
        {
            this.AuthorService = AuthorService;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await AuthorService.GetAuthor());
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("author/Change/{Id?}")]
        public async Task<IActionResult> ChangeAuthor(int? id)
        {
            if (id == null)
                return RedirectToAction();
            try
            {
                return View(await AuthorService.GetAuthor(id));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("author/Change/{Id?}")]
        public async Task<string> ChangeAuthor(AuthorDTO authorDTO)
        {
            try
            {
                await AuthorService.ChangeAuthor(authorDTO);
                return "пользователь изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("AddAuthor")]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("AddAuthor")]
        public async Task<string> AddAuthor(AuthorDTO authorDTO)
        {
            try
            {
                await AuthorService.AddAuthor(authorDTO);
                return "Автор добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("SearchAuthor")]
        public IActionResult SearchAuthor()
        {
            return View();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("Result")]
        public async Task<IActionResult> Result(string pattern)
        {
            return View(await AuthorService.GetAuthor(pattern));
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("author/Delete/{Id?}")]
        public async Task<string> DeleteAuthor(AuthorDTO authorDTO, int? id)
        {
            if (id == null)
                return "Куда ты мальчик?";
            else
            {
                await AuthorService.DeleteAuthor(authorDTO);
                return "Автор удален";
            }
        }
    }
}
