using BL.DTOs;
using BL.Services.AuthServ;
using BL.Services.UserServ;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVC.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _authServ;

        public AuthController(IAuthService authServ)
        {
            _authServ = authServ;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Register");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegistrationDto user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            int result = await _authServ.RegisterUserAsync(user);
            if (result == -1)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View("Register");
            }
            if (result == -2)
            {
                ModelState.AddModelError("Name", "Username already taken!");
                return View("Register");
            } 
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            UserAuthDto? userAuth = _authServ.Login(userLogin);
            if (userAuth == null)
            {
                ModelState.AddModelError("Password", "Invalid credentials!");
                return View("Login");
            }
            await CreateTokenAsync(userAuth);
            return RedirectToAction("Index", "Home");
        }

        private async Task CreateTokenAsync(UserAuthDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Group.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("ChangePassword");

        }

        [Authorize, HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto input)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePassword");
            }
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return View("ChangePassword");
            }
            input.UserId = userId;
            if (!await _authServ.ChangePasswordAsync(input))
            {
                ModelState.AddModelError("Password", "Old password is invalid!");
            }
            return View("ChangePassword");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
