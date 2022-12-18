using DAL.Models;
using DAL;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWWishList : IUoWWishList
    {
        public IRepository<WishListItem> WishlistRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<Book> BookRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWWishList(BookReservationDbContext context,
            IRepository<WishListItem> wishlistRepository,
            IRepository<Book> bookRepository,
            IRepository<User> userRepository)
        {
            this.context = context;
            WishlistRepository = wishlistRepository;
            BookRepository = bookRepository;
            UserRepository = userRepository;
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
