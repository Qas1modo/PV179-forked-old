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

        public async Task<IActionResult> Index([FromForm] FilterForm form, int page = 1)
        {

            // Pragmatically show genres
			var genres = await genreService.GetAllGenres();
			var dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
			ViewBag.genres = dropDownItems;


            // Setup filter with form attribs
            bookFilter.Page = page < 1 ? 1 : page;
            bookFilter.GenreFilter = form.Genre;

            // Filter books
            var serviceResult = stockService.ShowBooks(bookFilter);

            // Prepare model
			var model = new MainPageIndexModel
            {
                Books = serviceResult.Items,
                Page = serviceResult.PageNumber ?? 1,
                Total = serviceResult.ItemsCount
            };

			return View(model);
        }

	}
}
