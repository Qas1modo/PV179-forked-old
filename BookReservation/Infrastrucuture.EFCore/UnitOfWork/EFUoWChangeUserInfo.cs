using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastrucure.Repository;
using Infrastrucure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWChangeUserInfo : IUoWChangeUserInfo
    {
        private IRepository<User> userRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWChangeUserInfo(DbContextOptions<BookReservationDbContext> options)
        {
            Context = new(options);
        }

        public EFUoWChangeUserInfo()
        {
            Context = new();
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
