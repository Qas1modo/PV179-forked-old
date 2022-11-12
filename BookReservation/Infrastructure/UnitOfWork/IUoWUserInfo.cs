using DAL.Models;
using Infrastrucure.Repository;


namespace Infrastructure.UnitOfWork
{
    public interface IUoWUserInfo : IUnitOfWork
    {
        IRepository<User> UserRepository { get; }

    }
}
