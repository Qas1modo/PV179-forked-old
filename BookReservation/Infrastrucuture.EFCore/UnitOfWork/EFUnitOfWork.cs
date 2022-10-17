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

        private DbContextOptions<BookReservationDbContext>? options;
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
            this.options = options;
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
                    this.addressRepository = new EFGenericRepository<Address>(Context);
                }

                return this.addressRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    this.authorRepository = new EFGenericRepository<Author>(Context);
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
                    this.bookRepository = new EFGenericRepository<Book>(Context);
                }

                return this.bookRepository;
            }
        }

        public IRepository<CartItem> CartItemRepository
        {
            get
            {
                if (cartItemRepository == null)
                {
                    this.cartItemRepository = new EFGenericRepository<CartItem>(Context);
                }

                return this.cartItemRepository;
            }
        }

        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    this.genreRepository = new EFGenericRepository<Genre>(Context);
                }

                return this.genreRepository;
            }
        }

        public IRepository<Rent> RentRepository
        {
            get
            {
                if (rentRepository == null)
                {
                    this.rentRepository = new EFGenericRepository<Rent>(Context);
                }

                return this.rentRepository;
            }
        }


        public IRepository<Review> ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    this.reviewRepository = new EFGenericRepository<Review>(Context);
                }

                return this.reviewRepository;
            }
        }

        public IRepository<ReviewPoint> ReviewPointRepository
        {
            get
            {
                if (reviewPointRepository == null)
                {
                    this.reviewPointRepository = new EFGenericRepository<ReviewPoint>(Context);
                }

                return this.reviewPointRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    this.userRepository = new EFGenericRepository<User>(Context);
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
