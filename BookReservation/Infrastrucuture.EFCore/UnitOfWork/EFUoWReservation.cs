using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;
using Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWReservation : IUoWReservation
    {
        private IRepository<Rent> rentRepository;

        public EFUoWReservation(BookReservationDbContext context)
        {
            Context = context;
        }

        public BookReservationDbContext Context { get; }

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
