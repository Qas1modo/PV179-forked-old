using BL.DTOs;
using BL.Services.StockServ;
using BL.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;


namespace WebAppMVC.Controllers
{
	public class AdminPageController : Controller
	{

		private readonly IUserService userService;
		private readonly IStockService stockService;

		private BookFilterDto bookFilter = new BookFilterDto { OnStock = false };

		public AdminPageController(IUserService userService, IStockService stockService) 
		{ 
			this.userService = userService;
			this.stockService = stockService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			var model = new AdminPageUsersModel();
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
	}
}
