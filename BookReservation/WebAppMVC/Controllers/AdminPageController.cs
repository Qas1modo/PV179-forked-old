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
			AdminChangeBookModel model = new()
			{
				AuthorName = book.Author.Name,
				GenreName = book.Genre.Name,
				Deleted = book.Deleted,
				Description = book.Description,
				Price = book.Price,
				Name = book.Name,
				Total = book.Total,
			};
            return View("ChangeBookInfo", model);

        }

		[HttpPost]
        public async Task<IActionResult> ChangeBookInfo(int id, AdminChangeBookModel model)
		{

            BookBasicInfoDto book = await bookService.GetBook(id);
            var newStock = book.Stock - (model.Total - book.Total);
			if (newStock < 0)
			{
				ModelState.AddModelError("Total" ,"New total cannot be applied!");
            }
			if (!ModelState.IsValid)
			{
                return View("ChangeBookInfo", book);
            }
			book.Name = model.Name;
			book.Stock = newStock;
			book.Total = model.Total;
			book.AuthorName = model.AuthorName;
			book.GenreName = model.GenreName;
            book.Description = model.Description;
			if (await bookService.UpdateBook(book.Id, book))
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
            AdminChangeBookModel newModel = new()
            {
                AuthorName = model.AuthorName,
                GenreName = book.GenreName,
                Deleted = book.Deleted,
                Description = book.Description,
                Price = book.Price,
                Name = book.Name,
                Total = book.Total,
            };
            return View("ChangeBookInfo", newModel);
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

			if (model.NewGenre.Name != null && model.NewGenre.Name != "")
			{
				model.Genre = model.NewGenre;
			} else if (model.GenreName != null)
			{ 
				model.Genre= new BL.DTOs.BasicDtos.GenreDto { Name = model.GenreName };
			}

			await bookFacade.AddBook(model.Author, model.Book, model.Genre);

			return RedirectToAction(nameof(Index));
        }
    }
}
