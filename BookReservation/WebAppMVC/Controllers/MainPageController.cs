using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
