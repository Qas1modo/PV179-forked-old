using DAL.Models;
using Infrastructure.Repository;


namespace Infrastructure.UnitOfWork
{
    public interface IUoWBook : IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }

        IRepository<Book> BookRepository { get; }

        IRepository<Genre> GenreRepository { get; }
    }
}
