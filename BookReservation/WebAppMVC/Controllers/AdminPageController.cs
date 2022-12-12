using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
	public class AdminPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			return View();
		}
	}
}
