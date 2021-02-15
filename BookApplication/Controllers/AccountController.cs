using Application.DTO;
using Application.Logic.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class AccountController : Controller
    {
        IUserService UserService { get; set; }

        public AccountController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Account/Index")]
        [HttpPost]
        public async Task<IActionResult> Index(UserDTO user)
        {
            var result = await UserService.GetUser(user);
            if (result != null)
            {
                await Authenticate(result);
                return RedirectToAction("Index", "Book");
            }
            else
                return StatusCode(404);
        }

        async Task Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleDTO.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "BookCookie", ClaimsIdentity.DefaultNameClaimType, 
                                                                         ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
