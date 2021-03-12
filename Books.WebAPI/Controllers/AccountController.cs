using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository UserRepository { get; set; }
        IClaimService ClaimService { get; set; }
        IMapper Mapper { get; set; }
        IUserService UserService { get; set; }

        public AccountController(IUserRepository userRepository, IClaimService claimService,
                                 IMapper mapper, IUserService userService)
        {
            UserRepository = userRepository;
            ClaimService = claimService;
            Mapper = mapper;
            UserService = userService;
        }

        [HttpGet("Account/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Out()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }

        [HttpPost("Account/Index")]
        public async Task<IActionResult> Index(UserDTO user)
        {
            try
            {
                var result = await UserRepository.GetUser(Mapper.Map<User>(user));
                if (result != null)
                {
                    await Authenticate(result);
                    return RedirectToAction("Index", "Book");
                }
                else
                    return View((object)user.Login);
            }
            catch
            {
                return StatusCode(403);
            }
        }

        async Task Authenticate(User user)
        {
            var id = ClaimService.Authenticate(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet("Account/Registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("Account/Registration")]
        public async Task<IActionResult> Registration(UserDTO dto)
        {
            var confirm = Request.Form["PasswordC"].ToString();
            if (confirm == dto.Password)
            {
                var user = await UserService.AddUser(Mapper.Map<User>(dto));

                if (user != null)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Book");
                }
                else
                    return View(new RegistrationError("Registration error: A user with this login already exists. Come up with a new login", ""));
            }
            else
                return View(new RegistrationError("Registration error: Password mismatch. Enter your password again", dto.Login));
        }
    }
}
