using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.ReviewService
{
	public interface IReviewService
	{
		public void AddReview(ReviewDto reviewDto);

		public void DeleteReview(int reviewId);

        public IEnumerable<ReviewDetailDto> ShowReviews(int bookId);
    }
}
