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
        private readonly IMapper _mapper;
		private readonly BookReservationDbContext _context;

        public ReviewService(BookReservationDbContext context, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
		}

		public void AddReview(ReviewDto reviewDto)
		{
            using IUoWReview uow = new EFUoWReview(_context);
            var reviewRepo = new CRUDService<DAL.Models.Review>(uow.ReviewRepository, _mapper);
            reviewRepo.Create<ReviewDto>(reviewDto);
            uow.Commit();
        }

        public void DeleteReview(int reviewId)
        {
            using IUoWReview uow = new EFUoWReview(_context);
            uow.ReviewRepository.Delete(reviewId);
            uow.Commit();
        }

        public IEnumerable<ReviewDetailDto> ShowReviews(int bookId)
		{
            using IUoWCartItems uow = new EFUoWCartItems(_context);
            Book book = uow.BookRepository.GetByID(bookId);
            IEnumerable<ReviewDetailDto> result = new List<ReviewDetailDto>();
            foreach (var bookReview in book.Reviews)
            {
                User user = uow.UserRepository.GetByID(bookReview.UserId);
                ReviewDetailDto item = _mapper.Map<ReviewDetailDto>(bookReview);
                item.Name = user.Name;
                result = result.Append(item);
            }
            return result;
        }
    }
}
