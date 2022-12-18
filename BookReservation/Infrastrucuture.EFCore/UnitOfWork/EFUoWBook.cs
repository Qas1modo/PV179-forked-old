using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWBook : IUoWBook
    {
        public IRepository<Book> BookRepository { get; }
        public IRepository<Genre> GenreRepository { get; }
        public IRepository<Author> AuthorRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWBook(BookReservationDbContext context,
            IRepository<Book> bookRepository,
            IRepository<Genre> genreRepository,
            IRepository<Author> authorRepository)
        {
            this.context = context;
            this.BookRepository = bookRepository;
            GenreRepository = genreRepository;
            AuthorRepository = authorRepository;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
