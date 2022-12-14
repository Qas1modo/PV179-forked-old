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
		public IActionResult Users(int page = 1)
		{
			page = page < 1 ? 1 : page;

			var model = new AdminPageUsersModel();

			var users = userService.ShowUsersPaging(page);

			model.Users = users.Items;
			model.Page = users.PageNumber ?? 1;
			model.Total = users.ItemsCount;

			return View(model);
		}

		[HttpGet("AdminPage/Books/{page?}")]
		public IActionResult Books(int page = 1)
		{

			var model = new AdminPageBooksModel();

			bookFilter.Page = page < 1 ? 1 : page;

			var serviceResult = stockService.ShowBooks(bookFilter);

			model.Books = serviceResult.Items;
			model.Page = serviceResult.PageNumber ?? 1;
			model.Total = serviceResult.ItemsCount / serviceResult.PageSize;

			return View(model);
		}

		public async Task<IActionResult> ChangeBookInfo(int id, BookDetailIndexModel model)
		{
			var book = await bookService.GetBook(id);

			if (book == null)
			{
				return RedirectToAction(nameof(Books));
			}

			if (model.bookInfo == null)
			{
				return View(new BookDetailIndexModel { bookInfo = book });
			}

			book.Author = model.bookInfo.Author;
			book.Name = model.bookInfo.Name;
			book.Stock = model.bookInfo.Stock;
			book.Description = model.bookInfo.Description;

			await bookService.UpdateBook(book.Id, book);

			return RedirectToAction(nameof(ChangeBookInfo), new { id = book.Id });
		}

		public async Task<IActionResult> AddBook()
		{
			// Get genres
            var genres = await genreService.GetAllGenres();
            SelectList dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
			ViewBag.genres = dropDownItems;

			return View(new AdminPageAddBookModel
			{
				Author = new(),
				Book = new(),
				Genre = new()
			});
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AdminPageAddBookModel model)
        {

			if (model.NewGenre != null && model.NewGenre.Name != "")
			{
				model.Genre = model.NewGenre;
			}

			await bookFacade.addBook(model.Author, model.Book, model.Genre);

			return RedirectToAction(nameof(Index));
        }
    }
}
