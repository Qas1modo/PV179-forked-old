using System;
using AutoMapper;
using DAL;
using Infrastructure.UnitOfWork;
using BL.DTOs.BasicDtos;
using Infrastructure.EFCore.UnitOfWork;
using DAL.Models;
using BL.DTOs;

namespace BL.Services.ReviewService
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

		public void AddReview(ReviewDto reviewDto)
		{
            uow.ReviewRepository.Insert(mapper.Map<Review>(reviewDto));
            uow.Commit();
        }

        public void DeleteReview(int reviewId)
        {
            uow.ReviewRepository.Delete(reviewId);
            uow.Commit();
        }

        public IEnumerable<ReviewDetailDto> ShowReviews(int bookId)
		{
            Book book = uow.BookRepository.GetByID(bookId);
            return mapper.Map<IEnumerable<ReviewDetailDto>>(book.Reviews);
        }
    }
}
