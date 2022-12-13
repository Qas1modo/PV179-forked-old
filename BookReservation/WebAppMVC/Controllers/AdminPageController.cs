using BL.DTOs;
using BL.Services.BookServ;
using BL.Services.ReviewServ;
using BL.Services.StockServ;
using BL.Services.UserServ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;


namespace WebAppMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminPageController : Controller
	{

		private readonly IUserService userService;
		private readonly IStockService stockService;
		private readonly IBookService bookService;


		private BookFilterDto bookFilter = new BookFilterDto { OnStock = false };

		public AdminPageController(IUserService userService, IStockService stockService,
			IBookService bookService)
		{
			this.userService = userService;
			this.stockService = stockService;
			this.bookService = bookService;
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

	}
}
