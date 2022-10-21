using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastrucure.Repository;
using Infrastrucure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWReservation : IUoWReservation
    {
        private IRepository<Rent> rentRepository;

        public EFUoWReservation(DbContextOptions<BookReservationDbContext> options)
        {
            Context = new(options);
        }

        public EFUoWReservation()
        {
            Context = new();
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

        public Task Commit()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
