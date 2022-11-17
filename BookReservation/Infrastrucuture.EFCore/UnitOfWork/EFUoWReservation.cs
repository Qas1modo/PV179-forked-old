using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWReservation : IUoWReservation
    {
        public IRepository<Rent> RentRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<User> UserRepository { get; }

        private BookReservationDbContext context;

        public EFUoWReservation(BookReservationDbContext context, IRepository<Rent> rentRepository,
            IRepository<Book> bookRepository, IRepository<User> userRepository)
        {
            this.context = context;
            RentRepository = rentRepository;
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
