using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.Review
{
	public interface IReviewService
	{
		public void AddReview(ReviewDto reviewDto);
	}
}
