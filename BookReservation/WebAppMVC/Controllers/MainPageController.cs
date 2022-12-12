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

        public IActionResult Index()
        {
            // Move to BL ?
            var filter = new BookFilterDto
            {
                OnStock = true,
                Page = 1
            };

            var model = new MainPageIndexModel
            {
                Books = stockService.ShowBooks(filter).Items
            };

			return View(model);
        }
        [HttpPost]
		public IActionResult Index(MainPageIndexModel model)
        {

			var filter = new BookFilterDto
			{
				OnStock = true,
				Page = 1
			};

			if (model.Page != null)
            {
                filter.Page = model.Page;
            }

            if (model.Genre != null)
            {
				filter.GenreFilter = model.Genre;
			}

			if (model.Author != null)
			{
				filter.AuthorFilter = model.Author;
			}

			var model2 = new MainPageIndexModel
			{
				Books = stockService.ShowBooks(filter).Items
			};

			return View(model2);

		}

	}
}
