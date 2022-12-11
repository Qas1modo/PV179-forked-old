using DAL.Models;
using DAL;
using Infrastructure.EFCore.Repository;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWCartItem : IUoWCartItem
    {
        public IRepository<CartItem> CartItemRepository { get; }

        public IRepository<User> UserRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWCartItem(BookReservationDbContext context,
            IRepository<CartItem> cartItemRepository,
            IRepository<User> userRepository)
        {
            this.context = context;
            this.CartItemRepository = cartItemRepository;
            this.UserRepository = userRepository;
        }


        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
