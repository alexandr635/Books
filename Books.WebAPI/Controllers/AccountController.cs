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

        public AccountController(IUserRepository userRepository, IClaimService claimService,
                                 IMapper mapper)
        {
            UserRepository = userRepository;
            ClaimService = claimService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Account/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Account/Index")]
        [HttpPost]
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
                    return StatusCode(401);
            }
            catch
            {
                return StatusCode(503);
            }
        }

        async Task Authenticate(User user)
        {
            var id = ClaimService.Authenticate(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
