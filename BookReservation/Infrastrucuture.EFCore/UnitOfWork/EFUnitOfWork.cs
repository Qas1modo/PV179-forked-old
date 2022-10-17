using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastrucure.Repository;
using Infrastrucure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;



namespace Infrastrucuture.EFCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IRepository<Author> authorRepository;
        private IRepository<User> userRepository;
        private IRepository<Address> addressRepository;
        private IRepository<Book> bookRepository;
        private IRepository<CartItem> cartItemRepository;
        private IRepository<Genre> genreRepository;
        private IRepository<Rent> rentRepository;
        private IRepository<Review> reviewRepository;
        private IRepository<ReviewPoint> reviewPointRepository;

        public BookReservationDbContext Context { get; }


        public EFUnitOfWork(DbContextOptions<BookReservationDbContext> options)
        {
            Context = new(options);
        }

        public EFUnitOfWork() 
        {
            Context = new();
        }


        public IRepository<Address> AddressRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    addressRepository = new EFGenericRepository<Address>(Context);
                }

                return addressRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new EFGenericRepository<Author>(Context);
                }

                return authorRepository;
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

        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new EFGenericRepository<Genre>(Context);
                }

                return genreRepository;
            }
        }

        public IRepository<Rent> RentRepository
        {
            get
            {
                if (rentRepository == null)
                {
                    rentRepository = new EFGenericRepository<Rent>(Context);
                }

                return rentRepository;
            }
        }


        public IRepository<Review> ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new EFGenericRepository<Review>(Context);
                }

                return reviewRepository;
            }
        }

        public IRepository<ReviewPoint> ReviewPointRepository
        {
            get
            {
                if (reviewPointRepository == null)
                {
                    reviewPointRepository = new EFGenericRepository<ReviewPoint>(Context);
                }

                return reviewPointRepository;
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
