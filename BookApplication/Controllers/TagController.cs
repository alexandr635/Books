using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class TagController : Controller
    {
        ITagService TagService { get; set; }

        public TagController(ITagService TagService)
        {
            this.TagService = TagService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await TagService.GetTag());
        }

        [HttpGet]
        [Route("/AddTag")]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        [Route("/AddTag")]
        public async Task<string> AddTag(TagDTO tagDTO)
        {
            try
            {
                await TagService.AddTag(tagDTO);
                return "Тэг добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("Tag/ChangeTag/{Id?}")]
        public async Task<IActionResult> ChangeTag(int? id)
        {
            try
            {
                return View(await TagService.GetTag(id));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [Route("Tag/ChangeTag/{Id?}")]
        public async Task<string> ChangeTag(TagDTO tagDTO)
        {
            try
            {
                await TagService.ChangeTag(tagDTO);
                return "Тэг изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("Tag/DeleteTag/{Id?}")]
        public async Task<string> DeleteTag(TagDTO tagDTO ,int? id)
        {
            if (id == null)
                return "go away";
            else
            {
                await TagService.DeleteTag(tagDTO);
                return "Тэг удален!";
            }
        }
    }
}
