using BL.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;


namespace WebAppMVC.Controllers
{
	public class AdminPageController : Controller
	{

		public IUserService userService;

		public AdminPageController(IUserService userService) 
		{ 
			this.userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			var model = new AdminPageUsersModel();
			return View(model);
		}
	}
}
