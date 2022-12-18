using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.ReviewServ
{
    public interface IReviewService
    {
        Task<bool> AddReview(ReviewDto reviewDto);

        Task<bool> DeleteReview(int reviewId, int userId = -1, bool commit = true);

        Task<QueryResultDto<ReviewDetailDto>> ShowReviews(int bookId, int page, int pageSize);
    }
}
