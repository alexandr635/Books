using Application.DTO;
using Application.Logic;
using Application.Logic.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService ReviewService { get; set; }
        IUserService UserService { get; set; }

        public ReviewController(IReviewService ReviewService, IUserService userService)
        {
            this.ReviewService = ReviewService;
            UserService = userService;
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
        public async Task<string> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                string name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                var user = await UserService.GetUser(name);
                reviewDTO.UserId = user.Id;
                reviewDTO.Pseudonim = name;
                await ReviewService.AddReview(reviewDTO);
                return "Отзыв добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
