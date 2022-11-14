using System;
using DAL.Models;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
	public interface IUoWCartItem : IUnitOfWork
	{
        IRepository<CartItem> CartItemRepository { get; }
    }
}

