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
        public IActionResult Index(int bookId)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId)
            };

            return View(model);
        }

        [Route("book/{bookId}/{showedReviews}")]
        public IActionResult MoreReviews(int bookId, int showedReviews)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId, showedReviews + 10)
            };

            return View("../BookDetail/Index", model);
        }

        [Route("book/AddToCart/{bookId}")]
        public IActionResult AddToCart(int bookId)
        {
            // TODO when user will be known
            // create cartitem
            // redirect to cart

            // for now do nothing
            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId)
            };

            return View("../BookDetail/Index", model);
        }

        [Route("book/AddReview/{bookId}")]
        public IActionResult AddReview([FromForm] ReviewForm form, int bookId)
        {
            // TODO when user will be known
            // probably just refresh the site

            ReviewDto newReview = new ReviewDto();
            //newReview.UserId = "neviem odkial zobrat";
            newReview.BookId = bookId;
            newReview.Score = form.inlineRadioOptions;
            newReview.Description = form.description;
            //reviewService.AddReview(newReview);


            // for now do nothing
            var model = new BookDetailIndexModel()
            {
                bookInfo = bookService.GetBook(bookId),
                reviews = reviewService.ShowReviews(bookId)
            };

            return View("../BookDetail/Index", model);
        }
    }
}

