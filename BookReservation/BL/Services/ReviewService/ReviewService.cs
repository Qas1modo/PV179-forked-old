using System;
using AutoMapper;
using DAL;
using Infrastructure.UnitOfWork;
using BL.DTOs.BasicDtos;
using Infrastructure.EFCore.UnitOfWork;
using DAL.Models;
using BL.DTOs;
using Infrastructure.Query;

namespace BL.Services.ReviewServ
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper mapper;
        private readonly IUoWReview uow;
        private readonly IQuery<Review> query;

        public ReviewService(IUoWReview uow,
            IMapper mapper,
            IQuery<Review> query)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.query = query;
        }

        public async Task<bool> AddReview(ReviewDto reviewDto)
        {
            int reviewCount = uow.ReviewRepository.GetQueryable()
                .Where(x => x.UserId == reviewDto.UserId)
                .Where(x => x.BookId == reviewDto.BookId)
                .Count();
            if (reviewCount > 0)
            {
                return false;
            }
            reviewDto.AddedAt = DateTime.Now;
            uow.ReviewRepository.Insert(mapper.Map<Review>(reviewDto));
            await uow.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteReview(int reviewId, int userId = -1, bool commit = true)
        {
            Review review = await uow.ReviewRepository.GetByID(reviewId);
            if (review.UserId != userId && userId != -1)
            {
                return false;
            }
            uow.ReviewRepository.Delete(reviewId);
            if (commit) await uow.CommitAsync();
            return true;
        }

        public async Task<QueryResultDto<ReviewDetailDto>> ShowReviews(int bookId, int page, int pageSize)
        {
            QueryResult<Review> result = await query
                .Where<int>(x => x == bookId, "BookId")
                .OrderBy<DateTime>("AddedAt")
                .Page(page, pageSize)
                .Execute(); 
            return mapper.Map<QueryResult<Review>, QueryResultDto<ReviewDetailDto>>(result);
        }
    }
}
