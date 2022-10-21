using DAL.Models;
using Infrastrucure.Repository;


namespace Infrastructure.UnitOfWork
{
    public interface IUoWChangeUserInfo : IUnitOfWork
    {
        IRepository<User> UserRepository { get; }

    }
}
