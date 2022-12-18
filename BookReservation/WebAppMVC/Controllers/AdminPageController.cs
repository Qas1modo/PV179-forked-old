using BL.DTOs;
using BL.Services.BookServ;
using BL.Services.GenreServ;
using BL.Services.ReviewServ;
using BL.Services.StockServ;
using BL.Services.UserServ;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppMVC.Models;
using BL.Facades.BookFac;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminPageController : Controller
	{

		private readonly IUserService userService;
		private readonly IStockService stockService;
		private readonly IBookService bookService;
		private readonly IGenreService genreService;
		private readonly IBookFacade bookFacade;


        private BookFilterDto bookFilter = new BookFilterDto { OnStock = false };

		public AdminPageController(IUserService userService, IStockService stockService,
			IBookService bookService, IGenreService genreService, IBookFacade bookFacade)
		{
			this.userService = userService;
			this.stockService = stockService;
			this.bookService = bookService;
			this.genreService = genreService;
			this.bookFacade = bookFacade;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("AdminPage/Users/{page?}")]
		public async Task<IActionResult> Users(int page = 1)
		{
			page = page < 1 ? 1 : page;

			var model = new AdminPageUsersModel();

			var users = await userService.ShowUsers(page);

			model.Users = users.Items;
			model.Page = users.PageNumber ?? 1;
			model.Total = users.ItemsCount;

			return View(model);
		}

		[HttpGet("AdminPage/Books/{page?}")]
		public async Task<IActionResult> Books(int page = 1)
		{

			var model = new AdminPageBooksModel();

			bookFilter.Page = page < 1 ? 1 : page;
			bookFilter.PageSize = 10;
            var serviceResult = await stockService.ShowBooks(bookFilter);

			model.Books = serviceResult.Items;
			model.Page = serviceResult.PageNumber ?? 1;
			model.Total = (serviceResult.ItemsCount - 1) / serviceResult.PageSize + 1;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> ChangeBookInfo(int id)
		{
            var genres = await genreService.GetAllGenres();
            SelectList dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
            ViewBag.genres = dropDownItems;

            BookBasicInfoDto book = await bookService.GetBook(id);
            if (book == null)
            {
                return RedirectToAction(nameof(Books));
            }
            BookChangeDto model = new()
			{
				NewAuthorName = book.Author.Name,
				NewGenreName = book.Genre.Name,
				Deleted = book.Deleted,
				Description = book.Description,
				Price = book.Price,
				Name = book.Name,
				Total = book.Total,
			};
            return View("ChangeBookInfo", model);

        }

		[HttpPost]
        public async Task<IActionResult> ChangeBookInfo(int id, BookChangeDto model)
		{

			if (!ModelState.IsValid)
			{
                return View("ChangeBookInfo", model);
            }
			if (await bookFacade.UpdateBook(id, model))
			{
                ModelState.AddModelError("Name", "Changes applied succesfully!");
            }
			else
			{
                ModelState.AddModelError("AuthorName", "Invalid author name!");
            }
            var genres = await genreService.GetAllGenres();
            SelectList dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
            ViewBag.genres = dropDownItems;
            return View("ChangeBookInfo", model);
        }

		public async Task<IActionResult> AddBook()
		{
			// Get genres
            var genres = await genreService.GetAllGenres();
            SelectList dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
			ViewBag.genres = dropDownItems;

			return View(new BookDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto model)
        {

			if (model.Genre.Name == null)
			{
                model.Genre = new Genre { Name = model.NewGenreName };
			}
			model.Total = model.Stock;
			model.Deleted = false;
			await bookFacade.AddBook(model);
			return RedirectToAction(nameof(Index));
        }
    }
}
