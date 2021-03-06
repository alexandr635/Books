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
    public class GenreController : Controller
    {
        IGenreRepository GenreRepository { get; set; }
        IMapper Mapper { get; set; }

        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            GenreRepository = genreRepository;
            Mapper = mapper;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre());
            return View(listDTO);
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
                await GenreRepository.AddGenre(Mapper.Map<Genre>(genreDTO));
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
                return View(await GenreRepository.GetGenre(id));
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
                await GenreRepository.ChangeGenre(Mapper.Map<Genre>(genreDTO));
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
                await GenreRepository.DeleteGenre(Mapper.Map<Genre>(genreDTO));
                return "Жанр удален!";
            }
        }
    }
}
