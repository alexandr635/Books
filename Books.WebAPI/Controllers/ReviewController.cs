using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService ReviewService { get; set; }
        IMapper Mapper { get; set; }

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            ReviewService = reviewService;
            Mapper = mapper;
        }

        [Authorize(Roles = "Читатель, Администратор")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Home/AddReview/{Id?}")]
        [Authorize(Roles = "Читатель, Администратор")]
        public IActionResult AddReview(int? id)
        {
            try
            {
                ViewData["Name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                return View(id);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost("Home/AddReview/{Id?}")]
        [Authorize(Roles = "Читатель, Администратор")]
        public async Task<IActionResult> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                string name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                await ReviewService.AddReview(name, Mapper.Map<Review>(reviewDTO));
                return RedirectToAction("Book", "Book", new { Id = reviewDTO.BookId});
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
