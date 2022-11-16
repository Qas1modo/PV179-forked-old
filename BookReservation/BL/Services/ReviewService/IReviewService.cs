using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.Review
{
	public interface IReviewService
	{
		public void AddReview(ReviewDto reviewDto);

		public IEnumerable<ReviewDetailDto> ShowReviews(int bookId);

		public void DeleteReview(int reviewId);
    }
}
