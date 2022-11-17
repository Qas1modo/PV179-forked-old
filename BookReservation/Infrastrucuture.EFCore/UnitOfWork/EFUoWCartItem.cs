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
        public IRepository<CartItem> CartItemRepository { get; }

        private BookReservationDbContext context;

        public EFUoWCartItem(BookReservationDbContext context, IRepository<CartItem> cartItemRepository)
		{
            this.context = context;
            CartItemRepository= cartItemRepository;
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

