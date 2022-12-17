using BL.Services.StockServ;
using Microsoft.AspNetCore.Mvc;
using BL.DTOs;
using WebAppMVC.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BL.Services.GenreServ;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebAppMVC.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IStockService stockService;

		private readonly IGenreService genreService;


		public MainPageController(IStockService stockService, IGenreService genreService)
        {
            this.stockService = stockService;
			this.genreService = genreService;
        }

        [Route("/{page:int?}/")]
        public async Task<IActionResult> Index([FromForm] FilterForm form,
            string? AuthorFilter,
            string? NameFilter,
            string? GenreFilter,
            bool? OnStock,
            string? OrderBy,
            bool? Ascending,
            int? page = 1)
        {
            const string allGenre = "All";
            // Pragmatically show genres
			var genres = await genreService.GetAllGenres();
            List<SelectListItem> dropDownItems = genres.Select(x => new SelectListItem { Value=x.Name, Text=x.Name }).ToList();
            dropDownItems.Insert(0, new SelectListItem { Value = allGenre, Text = allGenre });
            var orderColumns = new List<string> { "Name", "Price" };
            List<SelectListItem> orderBy = orderColumns.Select(x => new SelectListItem { Value = x, Text = x }).ToList();
            orderBy.Insert(0, new SelectListItem { Value = "None", Text = null });

            ViewBag.orderBy = orderBy;
            ViewBag.genres = dropDownItems;
            BookFilterDto filter = new()
            {
                NameFilter = form.BookName ?? NameFilter,
                AuthorFilter = form.Author ?? AuthorFilter,
                GenreFilter = form.Genre == allGenre ? null : form.Genre ?? GenreFilter,
                OnStock = OnStock ?? !(form.Stock),
                Page = page < 1 ? 1 : page,
                OrderBy = OrderBy ?? form.OrderColumn,
                Ascending = Ascending ?? form.SortAscending,
                PageSize = 15
            };
            // Filter books
            var serviceResult = stockService.ShowBooks(filter);
            // Prepare model
            var model = new MainPageIndexModel
            {
                Books = serviceResult.Items,
                Page = serviceResult.PageNumber ?? 1,
                AuthorFilter = filter.AuthorFilter,
                GenreFilter = filter.GenreFilter,
                NameFilter = filter.NameFilter,
                OrderBy = filter.OrderBy,
                Ascending = filter.Ascending ?? true,
                OnStock = filter.OnStock,
                Total = (serviceResult.ItemsCount - 1) / serviceResult.PageSize + 1
            };
			return View(model);
        }
	}
}
