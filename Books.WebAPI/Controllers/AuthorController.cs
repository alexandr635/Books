using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorRepository AuthorRepository { get; set; }
        IMapper Mapper { get; set; }

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            AuthorRepository = authorRepository;
            Mapper = mapper;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var toDTO = Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor());
                return View(toDTO);
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
                return View(await AuthorRepository.GetAuthor(id));
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
                await AuthorRepository.ChangeAuthor(Mapper.Map<Author>(authorDTO));
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
                await AuthorRepository.AddAuthor(Mapper.Map<Author>(authorDTO));
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
            return View(await AuthorRepository.GetAuthor(pattern));
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("author/Delete/{Id?}")]
        public async Task<string> DeleteAuthor(AuthorDTO authorDTO, int? id)
        {
            if (id == null)
                return "Куда ты мальчик?";
            else
            {
                await AuthorRepository.DeleteAuthor(Mapper.Map<Author>(authorDTO));
                return "Автор удален";
            }
        }
    }
}
