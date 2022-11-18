using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWReservation : IUoWReservation
    {
        public IRepository<Reservation> ReservationRepository { get; }
        public IRepository<User> UserRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWReservation(BookReservationDbContext context,
            IRepository<Reservation> reservationRepository,
            IRepository<Book> bookRepository,
            IRepository<User> userRepository)
        {
            this.context = context;
            ReservationRepository = reservationRepository;
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
