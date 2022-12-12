using System;
using AutoMapper;
using DAL;
using Infrastructure.UnitOfWork;
using BL.DTOs.BasicDtos;
using Infrastructure.EFCore.UnitOfWork;
using DAL.Models;
using BL.DTOs;

namespace BL.Services.ReviewServ
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper mapper;
        private readonly IUoWReview uow;

        public ReviewService(IUoWReview uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task AddReview(ReviewDto reviewDto)
        {
            uow.ReviewRepository.Insert(mapper.Map<Review>(reviewDto));
            await uow.CommitAsync();
        }

        public async Task DeleteReview(int reviewId)
        {
            uow.ReviewRepository.Delete(reviewId);
            await uow.CommitAsync();
        }

        public async Task<IEnumerable<ReviewDetailDto>> ShowReviews(int bookId, int number)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            return mapper.Map<IEnumerable<ReviewDetailDto>>(book.Reviews.Take(number));
        }
    }
}
