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

        [Route("mainpage/{page?}")]
        public async Task<IActionResult> Index([FromForm] FilterForm form, int page = 1)
        {
            const string allGenre = "All";

            // Pragmatically show genres
			var genres = await genreService.GetAllGenres();
            List<SelectListItem> dropDownItems = genres.Select(x => new SelectListItem { Value=x.Name, Text=x.Name }).ToList();
            dropDownItems.Insert(0, new SelectListItem { Value = allGenre, Text = allGenre });
            
            ViewBag.genres = dropDownItems;


            // Setup filter with form attribs
            bookFilter.Page = page < 1 ? 1 : page;
            bookFilter.GenreFilter = form.Genre == allGenre ? null : form.Genre; 

            // Null - on stock, NotNull - everything
            bookFilter.OnStock = form.Stock == null;

            bookFilter.AuthorFilter = form.Author;

            bookFilter.NameFilter = form.BookName;

			// Filter books
			var serviceResult = stockService.ShowBooks(bookFilter);

            // Prepare model
			var model = new MainPageIndexModel
            {
                Books = serviceResult.Items,
                Page = serviceResult.PageNumber ?? 1,
                Total = serviceResult.ItemsCount / serviceResult.PageSize
            };

			return View(model);
        }

	}
}
