using DAL.Models;
using Infrastrucure.Repository;


namespace Infrastructure.UnitOfWork
{
    public interface IUoWBook : IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }

        IRepository<Book> BookRepository { get; }

        IRepository<Genre> GetRepository { get; }
    }
}
