using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BL.Services.BookServ;
using BL.Services.ReviewServ;
using BL.Services.CartItemServ;
using WebAppMVC.Models;
using BL.DTOs.BasicDtos;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVC.Controllers
{
    public class BookDetailController : CommonController
    {
        private readonly IBookService bookService;

        private readonly IReviewService reviewService;

        private readonly ICartItemService cartItemService;

        public BookDetailController(IBookService bookService,
            IReviewService reviewService,
            ICartItemService cartItemService)
        {
            this.bookService = bookService;
            this.reviewService = reviewService;
            this.cartItemService = cartItemService;
        }

        [Route("book/{bookId}")]
        public async Task<IActionResult> Index(int bookId)
        {
            var model = new BookDetailIndexModel()
            {
                bookInfo = await bookService.GetBook(bookId),
                reviews = await reviewService.ShowReviews(bookId),
                group = GetGroup()
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

        [Authorize]
        [Route("book/AddToCart/{bookId}")]
        public async Task<IActionResult> AddToCart([FromForm] AddToCartForm form, int bookId)
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
            }

            CartItemDto newItem = new CartItemDto();
            newItem.BookId = bookId;
            newItem.UserId = userId;
            newItem.LoanPeriod = form.days;
            await cartItemService.AddItem(newItem);

            return RedirectToAction(nameof(Index), new { bookId = bookId });
        }

        [Authorize]
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

