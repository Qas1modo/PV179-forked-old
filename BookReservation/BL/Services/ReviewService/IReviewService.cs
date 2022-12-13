using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.ReviewServ
{
    public interface IReviewService
    {
        Task AddReview(ReviewDto reviewDto);

        Task DeleteReview(int reviewId);

        Task<IEnumerable<ReviewDetailDto>> ShowReviews(int bookId, int number = 5);
    }
}
