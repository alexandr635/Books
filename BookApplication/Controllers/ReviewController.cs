using Application.DTO;
using Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService ReviewService { get; set; }

        public ReviewController(IReviewService ReviewService)
        {
            this.ReviewService = ReviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/AddReview/{Id?}")]
        [HttpGet]
        public IActionResult AddReview(int? id)
        {
            try
            {
                return View(id);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [Route("Home/AddReview/{Id?}")]
        [HttpPost]
        public async Task<string> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
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
