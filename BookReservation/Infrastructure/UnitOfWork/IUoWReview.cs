using System;
using DAL.Models;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
	public interface IUoWReview : IUnitOfWork
	{
        IRepository<Review> ReviewRepository { get; }

        IRepository<Book> BookRepository { get; }

        IRepository<User> UserRepository { get; }
    }
}
