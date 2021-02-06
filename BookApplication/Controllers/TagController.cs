using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class TagController : Controller
    {
        ITagQuery tagQuery { get; set; }

        public TagController(ITagQuery tagQuery)
        {
            this.tagQuery = tagQuery;
        }

        public async Task<IActionResult> Index()
        {
            HashSet<TagDTO> tags = await tagQuery.GetTag();
            return View(tags);
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
                await tagQuery.AddTag(tagDTO);
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
                TagDTO tagDTO = await tagQuery.GetTag(id);
                return View(tagDTO);
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
                await tagQuery.ChangeTag(tagDTO);
                return "Тэг изменен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
