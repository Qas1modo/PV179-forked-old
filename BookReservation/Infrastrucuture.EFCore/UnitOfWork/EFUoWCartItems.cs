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
    public class EFUoWCartItems : IUoWCartItems
    {
        public IRepository<CartItem> CartItemRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<User> UserRepository { get; }

        private BookReservationDbContext context;

        public EFUoWCartItems(BookReservationDbContext context, IRepository<CartItem> cartItemRepository,
            IRepository<Book> bookRepository, IRepository<User> userRepository)
        {
            this.context = context;
            CartItemRepository = cartItemRepository;
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
