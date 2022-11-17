using System;
using AutoMapper;
using DAL;
using Infrastructure.UnitOfWork;
using BL.DTOs.BasicDtos;
using Infrastructure.EFCore.UnitOfWork;
using DAL.Models;
using BL.Services.CRUD;
using BL.DTOs;

namespace BL.Services.Review
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
            uow.ReviewRepository.Insert(mapper.Map<DAL.Models.Review>(reviewDto));
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
            IEnumerable<ReviewDetailDto> result = new List<ReviewDetailDto>();
            foreach (var bookReview in book.Reviews)
            {
                ReviewDetailDto item = mapper.Map<ReviewDetailDto>(bookReview);
                User user = uow.UserRepository.GetByID(bookReview.UserId);
                item.Name = user.Name;
                result = result.Append(item);
            }
            return result;
        }
    }
}
