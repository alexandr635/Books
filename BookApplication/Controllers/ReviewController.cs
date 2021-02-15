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

        [Route("Home/AddReview/{Id?}")]
        [HttpGet]
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

        [Route("Home/AddReview/{Id?}")]
        [HttpPost]
        [Authorize(Roles = "Читатель, Администратор")]
        public async Task<string> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                string name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                var user = UserService.GetUser(name);
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
