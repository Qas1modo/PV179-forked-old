using BL.Services.StockServ;
using Microsoft.AspNetCore.Mvc;
using BL.DTOs;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IStockService stockService;

        public MainPageController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        public IActionResult Index()
        {

            //var filter = new BookFilterDto
            //{
            //    OnStock = true,
            //    Page = 1
            //};

            //var model = new MainPageIndexModel()
            //{
            //    Items = stockService.ShowBooks(filter).Items;
            //};

			return View();
        }
    }
}
