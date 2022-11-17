using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWUserInfo : IUoWUserInfo
    {
        public IRepository<User> UserRepository { get; }

        private BookReservationDbContext context;

        public EFUoWUserInfo(BookReservationDbContext context, IRepository<User> userRepository)
        {
            this.context = context;
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
