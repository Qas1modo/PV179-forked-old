using System;
using AutoMapper;
using Infrastructure.UnitOfWork;
using BL.Services.BookServ;
using BL.Services.ReviewServ;
using DAL.Models;
using BL.DTOs;

namespace BL.Facades.BookFac
{
    public class BookFacade : IBookFacade
    {
        private readonly IBookService bookService;
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;


        public BookFacade(IBookService bookService,
            IReviewService reviewService,
            IMapper mapper)
        {
            this.bookService = bookService;
            this.reviewService = reviewService;
            this.mapper = mapper;
        }

        public void GetBookDetail(int bookId)
        {
            BookDetailInfoDto book = bookService.GetBook(bookId);
            IEnumerable<ReviewDetailDto> reviews = reviewService.ShowReviews(bookId);
        }
    }
}

