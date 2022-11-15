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
        private IRepository<CartItem> cartItemRepository;
        private IRepository<Book> bookRepository;
        private IRepository<User> userRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWCartItems(BookReservationDbContext context)
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
