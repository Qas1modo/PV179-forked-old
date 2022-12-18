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
using AutoMapper;
using BL.Facades.UserFac;
using Microsoft.Extensions.Configuration.UserSecrets;
using DAL.Enums;
using BL.Facades.OrderFac;

namespace WebAppMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminPageController : CommonController
	{

		private readonly IUserService userService;
		private readonly IStockService stockService;
		private readonly IBookService bookService;
		private readonly IGenreService genreService;
		private readonly IBookFacade bookFacade;
        private readonly IUserFacade userFacade;
        private readonly IOrderFacade orderFacade;
        private readonly IMapper mapper;

		public AdminPageController(IUserService userService,
			IStockService stockService,
			IBookService bookService,
			IGenreService genreService,
			IBookFacade bookFacade,
			IMapper mapper,
			IOrderFacade orderFacade,
			IUserFacade userFacade)
		{
			this.userService = userService;
			this.stockService = stockService;
			this.bookService = bookService;
			this.genreService = genreService;
			this.bookFacade = bookFacade;
			this.mapper = mapper;
			this.userFacade = userFacade;
			this.orderFacade = orderFacade;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("AdminPage/Users/{page:int?}")]
		public async Task<IActionResult> Users(int page = 1)
		{
			page = page < 1 ? 1 : page;
            var users = await userService.ShowUsers(page);
            var model = new AdminPageUsersModel
			{
				Users = users.Items,
				Page = page,
				Total = users.ItemsCount,
				SignedUser = GetValidUser(null),
			};
			return View(model);
		}

		[HttpGet("AdminPage/Books/{page:int?}")]
		public async Task<IActionResult> Books(int page = 1)
		{

			var model = new AdminPageBooksModel();
			BookFilterDto bookFilter = new()
			{
				Page = page < 1 ? 1 : page,
				PageSize = 10
			};
			var serviceResult = await stockService.ShowBooks(bookFilter);

			model.Books = serviceResult.Items;
			model.Page = serviceResult.PageNumber ?? 1;
			model.Total = (serviceResult.ItemsCount - 1) / serviceResult.PageSize + 1;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> ChangeBookInfo(int id)
		{
			await GetGenreList();
            BookBasicInfoDto book = await bookService.GetBook(id);
            if (book == null)
            {
                return RedirectToAction(nameof(Books));
            }
			return View("ChangeBookInfo", mapper.Map<AdminPageBookModel>(book));

        }

		private async Task GetGenreList()
		{
            var genres = await genreService.GetAllGenres();
            SelectList dropDownItems = new SelectList(genres.Select(x => new KeyValuePair<string, string>(x.Name, x.Name)), "Key", "Value");
            ViewBag.genres = dropDownItems;
        }

		[HttpPost]
        public async Task<IActionResult> ChangeBookInfo(int id, AdminPageBookModel model)
		{
            await GetGenreList();
            if (!ModelState.IsValid)
            {
                return View("ChangeBookInfo", model);
            }
            if (model.NewGenreName != null)
            {
                model.GenreName =  model.NewGenreName;
            }
			if (await bookFacade.UpdateBook(id, mapper.Map<BookDto>(model)))
			{
                ModelState.AddModelError("Name", "Changes applied succesfully!");
            }
			else
			{
                ModelState.AddModelError("AuthorName", "Invalid author name!");
            }
            return View("ChangeBookInfo", model);
        }

		public async Task<IActionResult> AddBook()
		{
            await GetGenreList();
            return View(new AdminPageBookModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AdminPageBookModel model)
        {
            await GetGenreList();
            if (!ModelState.IsValid)
            {
                return View("AddBook", model);
            }
            if (model.NewGenreName != null)
			{
                model.GenreName = model.NewGenreName;
			}
            BookDto bookDto = mapper.Map<BookDto>(model);
            await bookFacade.AddBook(bookDto);
            ModelState.AddModelError("Name", "Book created succesfully!");
            return View("AddBook", model);
        }

		[HttpPost]
		public async Task<IActionResult> ChangeGroup(int userId, string newgroup)
		{
			if (GetValidUser(null) == userId)
			{
                return RedirectToAction("Users");
            }
			if (!Enum.TryParse(newgroup, true, out Group group))
			{
                return RedirectToAction("Users");
            }
			await userService.UpdateUserPermission(userId, group);
            return RedirectToAction("Users");
        }

		public async Task<IActionResult> Deleteuser(int userId)
		{
			await userFacade.DeleteUser(userId);
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await bookFacade.DeleteBook(bookId);
            return Redirect("Books");
        }

		public async Task<IActionResult> ExpireOldReservations()
		{
			await orderFacade.ExpireOldReservations();
            ModelState.AddModelError("Id", "Reserations manually expired!");
            return View("Index");
		}
    }
}
