using BL.Services.StockServ;
using Microsoft.AspNetCore.Mvc;
using BL.DTOs;
using WebAppMVC.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BL.Services.GenreServ;

namespace WebAppMVC.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IStockService stockService;

		private readonly IGenreService genreService;

        private BookFilterDto bookFilter = new BookFilterDto
        {
            OnStock = true,
        };


		public MainPageController(IStockService stockService, IGenreService genreService)
        {
            this.stockService = stockService;
			this.genreService = genreService;
        }

        [HttpGet("MainPage/{page?}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            
            // Pragmatically show genres
			var genres = await genreService.GetAllGenres();
			var dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
			ViewBag.genres = dropDownItems;

            bookFilter.Page = page < 1 ? 1 : page;

            var model = new MainPageIndexModel
            {
                Books = stockService.ShowBooks(bookFilter).Items
            };

			return View(model);
        }

	}
}
