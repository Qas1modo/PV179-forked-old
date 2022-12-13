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

        public async Task<IActionResult> ChangeBookInfo(int id)
		{
			var model = new BookDetailIndexModel()
			{
                bookInfo = await bookService.GetBook(id),
                reviews = null
            };

            return View(model);
		}

		public async Task<IActionResult> EditBookInfo(BookDetailIndexModel model)
		{
			var book = await bookService.GetBook(model.bookInfo.Id);

			book.Author = model.bookInfo.Author;
			book.Name = model.bookInfo.Name;
			book.Stock = model.bookInfo.Stock;

			// udpate book -- change service to accept book BookBasicInfoDto since BookDto is not used at all
			return RedirectToAction(nameof(ChangeBookInfo), new { id = book.Id });
		}
	}
}
