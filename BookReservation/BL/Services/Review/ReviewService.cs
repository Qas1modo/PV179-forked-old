using System;
using AutoMapper;
using DAL;
using Infrastructure.UnitOfWork;
using BL.DTOs.BasicDtos;
using Infrastructure.EFCore.UnitOfWork;
using DAL.Models;
using BL.Services.CRUD;

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
			using (IUoWReview uow = new EFUoWReview(_context))
			{
				var reviewRepo = new CRUDService<DAL.Models.Review>(uow.ReviewRepository, _mapper);
				reviewRepo.Create<ReviewDto>(reviewDto);
				uow.Commit();
			}
        }
	}
}
