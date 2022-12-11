using BL.DTOs;
using BL.Services.UserServ;
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
            if(!ModelState.IsValid)
            {
                return View("ChangeInfo");
            }
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return View();
            }
            int result = await _userService.UpdateUserDataAsync(input, userId);
            if (result == -1)
            {
                ModelState.AddModelError("Email", "Email already taken!");
            }
            if (result == -2)
            {
                ModelState.AddModelError("Name", "Username already taken!");
            }
            if (result == -3)
            {
                ModelState.AddModelError("BirthDate", "Birthday must be more than three years before today!");
            }
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
