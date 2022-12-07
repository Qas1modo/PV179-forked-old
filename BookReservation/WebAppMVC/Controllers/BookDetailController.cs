using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BL.Services.BookServ;
using BL.Services.ReviewServ;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class BookDetailController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBookService bookService;

        private readonly IReviewService reviewService;

        public BookDetailController(ILogger<HomeController> logger,
            IBookService bookService,
            IReviewService reviewService)
        {
            _logger = logger;
            this.bookService = bookService;
            this.reviewService = reviewService;
        }

        public IActionResult Index(int bookId)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId)
            };

            return View(model);
        }

        public IActionResult MoreReviews(int bookId, int showedReviews)
        {

            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId, showedReviews + 10)
            };

            return View(model);
        }

        public IActionResult Add(int bookId)
        {
            return NotFound();
        }
    }
}

