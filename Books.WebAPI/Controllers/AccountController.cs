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
        IConverterService ConverterService { get; set; }
        IHashService HashService { get; set; }

        public AccountController(IUserRepository userRepository, IClaimService claimService,
                                 IMapper mapper, IUserService userService,
                                 IConverterService converterService, IHashService hashService)
        {
            UserRepository = userRepository;
            ClaimService = claimService;
            Mapper = mapper;
            UserService = userService;
            HashService = hashService;
            ConverterService = converterService;
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
                user.Password = HashService.GetHashPassword(user.Password);
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
                    ViewData["Error"] = "Registration error: A user with this login already exists. Come up with a new login";
            }
            else
                ViewData["Error"] = "Registration error: Password mismatch. Enter your password again";

            return View(dto.Login);
        }

        [HttpGet("Account/ChangeProfile")]
        public async Task<IActionResult> ChangeProfile()
        {
            try
            {
                var name = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType).Value.ToString();
                var user = Mapper.Map<UserDTO>(await UserRepository.GetUser(name));
                return View(user);
            }
            catch
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost("Account/ChangeProfile")]
        public async Task<IActionResult> ChangeProfile(UserDTO user)
        {       
            var newPass = Request.Form["NPassword"].ToString();
            var confirmPass = Request.Form["CPassword"].ToString();
            var name = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType).Value.ToString();
            user.Login = name;

            if (Request.Form.Files.Count != 0)
                user.Image = await ConverterService.ImageToByte(Request.Form.Files[0]);

            ViewData["Error"] = await UserService.ChangeUser(Mapper.Map<User>(user), newPass, confirmPass);
            user = Mapper.Map<UserDTO>(await UserRepository.GetUser(name));

            return View(user);
        }
    }
}
