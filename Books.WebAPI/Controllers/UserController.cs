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

namespace Books.WebAPI.Controllers
{
    public class UserController : Controller
    {
        IUserService UserService { get; set; }
        IUserRepository UserRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IMapper Mapper { get; set; }
        IListService ListService { get; set; }

        public UserController(IUserService userService, IUserRepository userRepository,
                              IRoleRepository roleRepository, IMapper mapper,
                              IListService listService)
        {
            UserService = userService;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            Mapper = mapper;
            ListService = listService;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<UserDTO>>(await UserRepository.GetUser());
            return View(listDTO);
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
        public async Task<string> Change(UserDTO user)
        {
            await UserRepository.ChangeUserRole(Mapper.Map<User>(user));
            return "Пользователь изменен";
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

        [HttpGet("User/Favorite/{Id?}")]
        public async Task<IActionResult> GetFavorite(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Book");

            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserRepository.GetUserWithBooks(name));

            return View(userDTO);
        }

        [HttpGet("User/Rent/{Id?}")]
        public async Task<IActionResult> GetRent(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Book");

            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userDTO = Mapper.Map<UserDTO>(await UserRepository.GetUserWithBooks(name));

            return View(userDTO);
        }
    }
}
