using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.ReviewService
{
	public interface IReviewService
	{
		void AddReview(ReviewDto reviewDto);

		void DeleteReview(int reviewId);

        IEnumerable<ReviewDetailDto> ShowReviews(int bookId);
    }
}
