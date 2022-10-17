using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastrucure.Repository;
using Infrastrucure.EFCore.Repository;



namespace Infrastrucuture.EFCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public BookReservationDbContext Context { get; } = new();

        private IRepository<Address> addressRepository
        {
            get
            {
                return addressRepository ?? new EFGenericRepository<Address>(Context);
            }
        }

        private IRepository<Author> authorRepository
        {
            get
            {
                return authorRepository ?? new EFGenericRepository<Author>(Context);
            }
        }

        private IRepository<Book> bookRepository
        {
            get
            {
                return bookRepository ?? new EFGenericRepository<Book>(Context);
            }
        }

        private IRepository<CartItem> cartItemRepository
        {
            get
            {
                return cartItemRepository ?? new EFGenericRepository<CartItem>(Context);
            }
        }

        private IRepository<Genre> genreRepository
        {
            get
            {
                return genreRepository ?? new EFGenericRepository<Genre>(Context);
            }
        }

        private IRepository<Rent> rentRepository
        {
            get
            {
                return rentRepository ?? new EFGenericRepository<Rent>(Context);
            }
        }


        private IRepository<Review> reviewRepository
        {
            get
            {
                return reviewRepository ?? new EFGenericRepository<Review>(Context);
            }
        }

        private IRepository<ReviewPoint> reviewPointRepository
        {
            get
            {
                return reviewPointRepository ?? new EFGenericRepository<ReviewPoint>(Context);
            }
        }

        private IRepository<User> userRepository
        {
            get
            {
                return userRepository ?? new EFGenericRepository<User>(Context);
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
