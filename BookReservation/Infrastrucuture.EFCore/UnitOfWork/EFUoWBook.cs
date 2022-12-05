using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWBook : IUoWBook
    {
        public IRepository<Book> BookRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWBook(BookReservationDbContext context,
            IRepository<Book> bookRepository)
        {
            this.context = context;
            this.BookRepository= bookRepository;
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
