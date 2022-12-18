using DAL.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUoWUser : IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Review> ReviewRepository { get; }
        IRepository<Reservation> ReservationRepository { get; }
    }
}
