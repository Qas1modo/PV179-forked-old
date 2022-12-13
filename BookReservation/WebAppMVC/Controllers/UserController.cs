using BL.DTOs;
using BL.Services.ReservationServ;
using BL.Services.UserServ;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    [Route("/User/{id:int?}"), Authorize]
    public class UserController : CommonController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet, Route("changeinfo")]
        public async Task<IActionResult> ChangeInfo(int? id)
        {
            int userId = GetValidUser(id);
            ViewBag.userId = userId;
            if (userId == -1)
            {
                return View("Index", "MainPage");
            }
            return View(await _userService.ShowUserData(userId));
        }

        [HttpPost, Route("changeinfo")]
        public async Task<IActionResult> ChangeInfoAsync(int? id, PersonalInfoDto input)
        {
            int userId = GetValidUser(id);
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
            return View("Index", await _userService.ShowUserData(userId));
        }
        public async Task<IActionResult> Index(int? id)
        {
            
            int userId = GetValidUser(id);
            if (!int.TryParse(User.Identity?.Name, out int signedUserId))
            {
                return View("Index", "MainPage");
            }
            ViewBag.showChange = signedUserId == userId;
            return View(await _userService.ShowUserData(userId));
        }
    }
}
