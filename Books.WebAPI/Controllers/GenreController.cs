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

        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre());
            return View(listDTO);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("addGenre")]
        public IActionResult AddGenre()
        {
            return View();
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("addGenre")]
        public async Task<IActionResult> AddGenre(GenreDTO genreDTO)
        {
            try
            {
                await GenreRepository.AddGenre(Mapper.Map<Genre>(genreDTO));
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return StatusCode(403);
            }
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("Genre/Change/{Id?}")]
        public async Task<IActionResult> ChangeGenre(int? id)
        {
            if (id == null)
                RedirectToAction();
            try
            {
                var dto = Mapper.Map<GenreDTO>(await GenreRepository.GetGenre(id));
                return View(dto);
            }
            catch
            {
                return StatusCode(403);
            }

        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("Genre/Change/{Id?}")]
        public async Task<IActionResult> ChangeGenre(GenreDTO genreDTO)
        {
            try
            {
                await GenreRepository.ChangeGenre(Mapper.Map<Genre>(genreDTO));
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return StatusCode(403);
            }
        }

        [Authorize(Roles = "Проверяющий")]
        [Route("Genre/Delete/{Id?}")]
        public async Task<IActionResult> DeleteGenre(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Account");
            else
            {
                await GenreRepository.DeleteGenre((int)id);
                return RedirectToAction("Index", "Genre");
            }
        }
    }
}
