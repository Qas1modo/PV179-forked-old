using System;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Repository;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;

namespace Infrastructure.EFCore.UnitOfWork
{
	public class EFUoWCartItem : IUoWCartItem
	{
        private IRepository<CartItem> cartItemRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWCartItem(BookReservationDbContext context)
		{
            Context = context;
        }

        public IRepository<CartItem> CartItemRepository
        {
            get
            {
                if (cartItemRepository == null)
                {
                    cartItemRepository = new EFGenericRepository<CartItem>(Context);
                }
                return cartItemRepository;
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

