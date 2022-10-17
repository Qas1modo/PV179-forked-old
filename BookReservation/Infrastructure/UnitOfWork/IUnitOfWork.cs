using DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        BookReservationDbContext Context { get; }
        Task Commit();
    }
}
