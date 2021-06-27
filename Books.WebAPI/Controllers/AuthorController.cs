using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> Index(DateTime birth, DateTime die, string name = null, int page = 1)
        {
            const int pageSize = 2;
            if (die == new DateTime(1, 1, 1))
                die = DateTime.Now;
            var author = new Author(name, birth, die);
            var authors = await AuthorRepository.GetAuthor(author);

            var filter = new FilterAuthorDTO()
            {
                MaxYearOfBirth = await AuthorRepository.GetMaxYear(),
                MinYearOfBirth = await AuthorRepository.GetMinYear(),
                Authors = Mapper.Map<List<AuthorDTO>>(authors.Skip((page - 1) * pageSize).Take(pageSize)),
                PageCount = (int)Math.Ceiling((decimal)authors.Count / pageSize),
                Name = name,
                DateOfBirth = birth,
                DateOfDie = die,
                Page = page
            };
                
            return View(filter);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("Author/Change/{Id?}")]
        public async Task<IActionResult> ChangeAuthor(int? id)
        {
            if (id == null)
                return RedirectToAction();

            var dto = Mapper.Map<AuthorDTO>(await AuthorRepository.GetAuthor(id));
            return View(dto);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("Author/Change/{Id?}")]
        public async Task<IActionResult> ChangeAuthor(AuthorDTO authorDTO)
        {
            if (authorDTO.DateOfBirth < authorDTO.DateOfDie)
            {
                await AuthorRepository.ChangeAuthor(Mapper.Map<Author>(authorDTO));
                return RedirectToAction("Index", "Author");
            }
            else
            {
                ViewData["Error"] = "Дата смерти автора не может быть раньше, чем дата его рождения. Измените дату!";
                return View(authorDTO);
            }
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("AddAuthor")]
        public IActionResult AddAuthor()
        {
            return View(null);
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AuthorDTO authorDTO)
        {
            if (authorDTO.DateOfBirth.Year == 1)
            {
                ViewData["Error"] = "Укажите дату рождения";
                return View(authorDTO);
            }    

            if (authorDTO.DateOfBirth < authorDTO.DateOfDie || authorDTO.DateOfDie == null)
            {
                await AuthorRepository.AddAuthor(Mapper.Map<Author>(authorDTO));
                return RedirectToAction("Index", "Author");
            }
            else
            {
                ViewData["Error"] = "Дата смерти автора не может быть раньше, чем дата его рождения.Измените дату!";
                return View(authorDTO);
            }
            
        }

        [Authorize(Roles = "Проверяющий")]
        [HttpGet("Author/Delete/{Id?}")]
        public async Task<IActionResult> DeleteAuthor(AuthorDTO authorDTO, int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Account");
            else
            {
                await AuthorRepository.DeleteAuthor(Mapper.Map<Author>(authorDTO));
                return RedirectToAction("Index", "Author");
            }
        }
    }
}
