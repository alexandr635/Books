using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Books.WebAPI.Controllers
{
    public class UserController : Controller
    {
        IUserService UserService { get; set; }
        IUserRepository UserRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IMapper Mapper { get; set; }
        IListService ListService { get; set; }
        IReviewRepository ReviewRepository { get; set; }

        public UserController(IUserService userService, IUserRepository userRepository,
                              IRoleRepository roleRepository, IMapper mapper,
                              IListService listService, IReviewRepository reviewRepository)
        {
            UserService = userService;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            Mapper = mapper;
            ListService = listService;
            ReviewRepository = reviewRepository;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index(string login = null, int page = 1)
        {
            var users = Mapper.Map<List<UserDTO>>(await UserRepository.GetFilterUser(login));
            const int pageSize = 4;

            var filter = new FilterUserDTO()
            {
                Login = login,
                Page = page,
                PageCount = (int)Math.Ceiling((decimal)users.Count / pageSize),
                Users = Mapper.Map<List<UserDTO>>(users.Skip((page - 1) * pageSize).Take(pageSize))
            };


            return View(filter);
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/Change/{Id?}")]
        public async Task<IActionResult> Change(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                return View(Mapper.Map<UserToRoleDTO>(await ListService.GetListUserAndRole((int)id)));
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("~/User/Change/{Id?}")]
        public async Task<IActionResult> Change(UserDTO user)
        {
            await UserRepository.ChangeUserRole(Mapper.Map<User>(user));
            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/Delete/{Id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                await UserService.DeleteUser((int)id);
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/AddUser")]
        public async Task<IActionResult> AddUser()
        {
            return View(await RoleRepository.GetRole());
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("~/User/AddUser")]
        public async Task<string> AddUser(UserDTO user)
        {
            var confirm = Request.Form["PasswordS"];
            if (user.Password == confirm)
            {
                await UserRepository.AddUser(Mapper.Map<User>(user));
                return "Пользователь добавлен";
            }
            else
            {
                return "Пароли не совпадают";
            }
        }

        [HttpGet("User/AddFavorite/{Id?}")]
        public async Task<bool> AddFavorite(int? id)
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserService.AddUserFavorite((int)id, name));

            return true;
        }

        [HttpGet("User/AddRent/{Id?}")]
        public async Task<bool> AddRent(int? id)
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserService.AddUserRent((int)id, name));

            return true;
        }

        [HttpGet("User/Favorite")]
        public async Task<IActionResult> GetFavorite()
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserRepository.GetUserWithBooks(name));

            return View(userDTO);
        }

        [HttpGet("User/Rent")]
        public async Task<IActionResult> GetRent()
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserRepository.GetUserWithBooks(name));

            return View(userDTO);
        }

        [HttpGet("User/Review")]
        public async Task<IActionResult> GetReview()
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<List<ReviewDTO>>(await ReviewRepository.GetReview(name));

            return View(userDTO);
        }
    }
}
