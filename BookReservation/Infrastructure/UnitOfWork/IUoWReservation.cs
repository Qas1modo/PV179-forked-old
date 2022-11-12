using DAL.Models;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public interface IUoWReservation : IUnitOfWork
    {
        IRepository<Rent> RentRepository { get; }
    }
}
