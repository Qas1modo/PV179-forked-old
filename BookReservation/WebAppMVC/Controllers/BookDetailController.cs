using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BL.Services.BookServ;
using BL.Services.ReviewServ;
using WebAppMVC.Models;
using BL.DTOs.BasicDtos;

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

        [Route("book/{bookId}")]
        public async Task<IActionResult> Index(int bookId)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = await bookService.GetBook(bookId),
                reviews = await reviewService.ShowReviews(bookId)
            };

            return View(model);
        }

        [Route("book/{bookId}/{showedReviews}")]
        public async Task<IActionResult> MoreReviews(int bookId, int showedReviews)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = await bookService.GetBook(bookId),
                reviews = await reviewService.ShowReviews(bookId, showedReviews + 10)
            };

            return View("../BookDetail/Index", model);
        }

        [Route("book/AddToCart/{bookId}")]
        public async Task<IActionResult> AddToCart(int bookId)
        {
            // TODO when user will be known
            // create cartitem
            // redirect to cart

            // for now do nothing
            var model = new BookDetailIndexModel()
            {
                bookInfo = await bookService.GetBook(bookId),
                reviews = await reviewService.ShowReviews(bookId)
            };

            return View("../BookDetail/Index", model);
        }

        [Route("book/AddReview/{bookId}")]
        public async Task<IActionResult> AddReview([FromForm] ReviewForm form, int bookId)
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
            }

            ReviewDto newReview = new ReviewDto();
            newReview.UserId = userId;
            newReview.BookId = bookId;
            newReview.Score = form.inlineRadioOptions;
            newReview.Description = form.description;
            await reviewService.AddReview(newReview);

            return RedirectToAction(nameof(Index), new { bookId = bookId }); ;
        }
    }
}

