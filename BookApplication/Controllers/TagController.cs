using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
                await TagService.AddTag(tagDTO);
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
                return View(await TagService.GetTag(id));
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
                await TagService.ChangeTag(tagDTO);
                return "Тэг изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("Tag/DeleteTag/{Id?}")]
        [Authorize(Roles = "Администратор")]
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
