using DAL.Models;
using Infrastrucure.Repository;

namespace Infrastructure.UnitOfWork
{
    public interface IUoWReservation : IUnitOfWork
    {
        IRepository<Rent> RentRepository { get; }
    }
}
