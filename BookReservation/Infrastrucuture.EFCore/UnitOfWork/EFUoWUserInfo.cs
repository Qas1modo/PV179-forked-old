using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;
using Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWUserInfo : IUoWUserInfo
    {
        private IRepository<User> userRepository;
        private IRepository<Address> addressRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWUserInfo(BookReservationDbContext context)
        {
            Context = context;
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

        public IRepository<Address> AddressRepository
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new EFGenericRepository<Address>(Context);
                }
                return addressRepository;
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
