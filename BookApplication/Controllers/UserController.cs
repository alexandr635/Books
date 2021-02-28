using Application.DTO;
using Application.Logic.Role;
using Application.Logic.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        IUserService UserService { get; set; }
        IRoleService RoleService { get; set; }

        public UserController(IUserService userService, IRoleService roleService)
        {
            UserService = userService;
            RoleService = roleService;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            return View(await UserService.GetUser());
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/Change/{Id?}")]
        public async Task<IActionResult> Change(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                UserToRoleDTO userToRole = new UserToRoleDTO()
                {
                    User = await UserService.GetUser((int)id),
                    Roles = await RoleService.GetRole()
                };
                return View(userToRole);
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("~/User/Change/{Id?}")]
        public async Task<string> Change(UserDTO user)
        {
            var confirm = Request.Form["PasswordS"];
            if (user.Password == confirm)
            {
                await UserService.ChangeUser(user);
                return "Пользователь изменен";
            }
            else
            {
                return "Пароли не совпадают";
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/Delete/{Id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                UserDTO user = new UserDTO();
                user.Id = (int)id;
                await UserService.DeleteUser(user);
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("~/User/AddUser")]
        public async Task<IActionResult> AddUser()
        {
            return View(await RoleService.GetRole());
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("~/User/AddUser")]
        public async Task<string> AddUser(UserDTO user)
        {
            var confirm = Request.Form["PasswordS"];
            if (user.Password == confirm)
            {
                await UserService.AddUser(user);
                return "Пользователь добавлен";
            }
            else
            {
                return "Пароли не совпадают";
            }
        }
    }
}
