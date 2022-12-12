using BL.DTOs;
using BL.Services.ReservationServ;
using BL.Services.UserServ;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [Authorize, HttpGet]
        public IActionResult ChangeInfo()
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return View();
            }
            return View(_userService.ShowUserData(userId));
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> ChangeInfoAsync(PersonalInfoDto input)
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                userId = -2;
            }
            if (input.BirthDate > DateTime.Now.AddYears(-3))
            {
                ModelState.AddModelError("BirthDate", "Birthday must be more than three years before today!");
               
            }
            int userByEmail = _userService.IdUserWithEmail(input.Email);
            int userByName = _userService.IdUserWithUsername(input.Name);
            if (userByEmail != -1 && userByEmail != userId)
            {
                ModelState.AddModelError("Email", "Email already taken!");
            }
            if (userByName != -1 && userByName!= userId)
            {
                ModelState.AddModelError("Name", "Username already taken!");
            }
            if (!ModelState.IsValid)
            {
                return View("ChangeInfo");
            }
            await _userService.UpdateUserDataAsync(input, userId);
            return View("ChangeInfo");
        }

        [Authorize]
        public IActionResult Index()
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return View("Index", "Home");
            }
            return View(_userService.ShowUserData(userId));
        }
    }
}
