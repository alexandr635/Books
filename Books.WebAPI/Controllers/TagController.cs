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
    public class TagController : Controller
    {
        ITagRepository TagRepository { get; set; }
        IMapper Mapper { get; set; }

        public TagController(ITagRepository tagRepository, IMapper mapper)
        {
            TagRepository = tagRepository;
            Mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<TagDTO>>(await TagRepository.GetTag());
            return View(listDTO);
        }

        [HttpGet("/AddTag")]
        [Authorize(Roles = "Проверяющий")]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost("/AddTag")]
        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> AddTag(TagDTO tagDTO)
        {
            await TagRepository.AddTag(Mapper.Map<Tag>(tagDTO));
            return RedirectToAction("Index", "Tag");
        }

        [HttpGet("Tag/ChangeTag/{Id?}")]
        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> ChangeTag(int? id)
        {
            try
            {
                var dto = Mapper.Map<TagDTO>(await TagRepository.GetTag(id));
                return View(dto);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost("Tag/ChangeTag/{Id?}")]
        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> ChangeTag(TagDTO tagDTO)
        {
            await TagRepository.ChangeTag(Mapper.Map<Tag>(tagDTO));
            return RedirectToAction("Index", "Tag");
        }

        [HttpGet("Tag/DeleteTag/{Id?}")]
        [Authorize(Roles = "Проверяющий")]
        public async Task<IActionResult> DeleteTag(TagDTO tagDTO, int? id)
        {
            if (id == null)
                return StatusCode(403);
            else
            {
                await TagRepository.DeleteTag(Mapper.Map<Tag>(tagDTO));
                return RedirectToAction("Index", "Tag");
            }
        }
    }
}
