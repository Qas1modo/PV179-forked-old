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

        public IRepository<User> UserRepository { get; }

        private BookReservationDbContext context;

        public EFUoWReview(BookReservationDbContext context, IRepository<Review> reviewRepository,
            IRepository<Book> bookRepository, IRepository<User> userRepository)
        {
            this.context = context;
            ReviewRepository = reviewRepository;
            BookRepository = bookRepository;
            UserRepository = userRepository;
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
