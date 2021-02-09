using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                HashSet<AuthorDTO> listAuthor = await AuthorService.GetAuthor();
                return View(listAuthor);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        [Route("author/Change/{Id?}")]
        public async Task<IActionResult> ChangeAuthor(int? id)
        {
            if (id == null)
                return RedirectToAction();
            try
            {
                AuthorDTO author = await AuthorService.GetAuthor(id);
                return View(author);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [Route("author/Change/{Id?}")]
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

        [HttpGet]
        [Route("AddAuthor")]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("AddAuthor")]
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

        [HttpGet]
        [Route("SearchAuthor")]
        public IActionResult SearchAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("Result")]
        public async Task<IActionResult> Result(string pattern)
        {
            var result = await AuthorService.GetAuthor(pattern);
            return View(result);
        }

        [HttpGet]
        [Route("author/Delete/{Id?}")]
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
