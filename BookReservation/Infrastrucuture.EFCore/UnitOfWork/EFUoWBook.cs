using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWBook : IUoWBook
    {
        public IRepository<Author> AuthorRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<Genre> GenreRepository { get; }

        private BookReservationDbContext context;

        public EFUoWBook(BookReservationDbContext context, IRepository<Author> authorRepository,
            IRepository<Book> bookRepository, IRepository<Genre> genreRepository)
        {
            this.context = context;
            AuthorRepository= authorRepository;
            BookRepository= bookRepository;
            GenreRepository =  genreRepository;
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
