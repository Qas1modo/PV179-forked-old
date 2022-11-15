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
        private IRepository<Review> reviewRepository;

        private IRepository<Book> bookRepository;

        private IRepository<User> userRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWReview(BookReservationDbContext context)
        {
            Context = context;
        }

        public IRepository<Review> ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new EFGenericRepository<Review>(Context);
                }
                return reviewRepository;
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new EFGenericRepository<Book>(Context);
                }
                return bookRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new EFGenericRepository<User>(Context);
                }
                return userRepository;
            }
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
