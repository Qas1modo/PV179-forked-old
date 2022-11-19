using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Infrastructure.UnitOfWork;
using DAL.Models;
using Infrastructure.Repository;
using Infrastructure.EFCore.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWReview : IUoWReview
    {
        public IRepository<Review> ReviewRepository { get; }

        public IRepository<Book> BookRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWReview(BookReservationDbContext context,
            IRepository<Review> reviewRepository,
            IRepository<Book> bookRepository)
        {
            this.context = context;
            this.ReviewRepository = reviewRepository;
            this.BookRepository = bookRepository;
        }


        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
