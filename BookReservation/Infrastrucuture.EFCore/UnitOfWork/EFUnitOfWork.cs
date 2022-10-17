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

        public IRepository<Address> AddressRepository
        {
            get
            {
                return AddressRepository ?? new EFGenericRepository<Address>(Context);
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                return AuthorRepository ?? new EFGenericRepository<Author>(Context);
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                return BookRepository ?? new EFGenericRepository<Book>(Context);
            }
        }

        public IRepository<CartItem> CartItemRepository
        {
            get
            {
                return CartItemRepository ?? new EFGenericRepository<CartItem>(Context);
            }
        }

        public IRepository<Genre> GenreRepository
        {
            get
            {
                return GenreRepository ?? new EFGenericRepository<Genre>(Context);
            }
        }

        public IRepository<Rent> RentRepository
        {
            get
            {
                return RentRepository ?? new EFGenericRepository<Rent>(Context);
            }
        }


        public IRepository<Review> ReviewRepository
        {
            get
            {
                return ReviewRepository ?? new EFGenericRepository<Review>(Context);
            }
        }

        public IRepository<ReviewPoint> ReviewPointRepository
        {
            get
            {
                return ReviewPointRepository ?? new EFGenericRepository<ReviewPoint>(Context);
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return UserRepository ?? new EFGenericRepository<User>(Context);
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
