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

        public IActionResult Index(string? author, string? genre, int? page, bool onStock = true)
        {
            // Move to BL ?
            var filter = new BookFilterDto
            {
                OnStock = true,
                Page = 1
            };

            if (page != null)
            {
                filter.Page = page;
            }

            if (genre != null)
            {
                filter.GenreFilter = genre;
            }

            if (author != null)
            {
                filter.AuthorFilter = author;
            }

            filter.OnStock = onStock;

            var model = new MainPageIndexModel
            {
                Books = stockService.ShowBooks(filter).Items
            };

			return View(model);
        }
    }
}
