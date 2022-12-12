using BL.Services.StockServ;
using Microsoft.AspNetCore.Mvc;
using BL.DTOs;
using WebAppMVC.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppMVC.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IStockService stockService;

        public MainPageController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet("MainPage/{page?}")]
        public IActionResult Index(int page = 1)
        {
            // Move to BL ?
            var filter = new BookFilterDto
            {
                OnStock = true,
                Page = page < 1 ? 1 : page
            };

            var model = new MainPageIndexModel
            {
                Books = stockService.ShowBooks(filter).Items
            };

			return View(model);
        }

	}
}
