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
        [Authorize(Roles = "Администратор")]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost("/AddTag")]
        [Authorize(Roles = "Администратор")]
        public async Task<string> AddTag(TagDTO tagDTO)
        {
            try
            {
                await TagRepository.AddTag(Mapper.Map<Tag>(tagDTO));
                return "Тэг добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("Tag/ChangeTag/{Id?}")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> ChangeTag(int? id)
        {
            try
            {
                return View(await TagRepository.GetTag(id));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost("Tag/ChangeTag/{Id?}")]
        [Authorize(Roles = "Администратор")]
        public async Task<string> ChangeTag(TagDTO tagDTO)
        {
            try
            {
                await TagRepository.ChangeTag(Mapper.Map<Tag>(tagDTO));
                return "Тэг изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("Tag/DeleteTag/{Id?}")]
        [Authorize(Roles = "Администратор")]
        public async Task<string> DeleteTag(TagDTO tagDTO, int? id)
        {
            if (id == null)
                return "go away";
            else
            {
                await TagRepository.DeleteTag(Mapper.Map<Tag>(tagDTO));
                return "Тэг удален!";
            }
        }
    }
}
