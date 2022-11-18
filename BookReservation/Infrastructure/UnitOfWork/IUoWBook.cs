using DAL.Models;
using Infrastructure.Repository;


namespace Infrastructure.UnitOfWork
{
    public interface IUoWBook : IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
    }
}
