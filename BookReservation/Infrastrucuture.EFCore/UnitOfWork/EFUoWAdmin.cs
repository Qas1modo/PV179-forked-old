using DAL.Models;
using DAL;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWAdmin: IUoWAdmin
    {
        public IRepository<User> UserRepository { get; }

        public IRepository<Book> BookRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWAdmin(BookReservationDbContext context,
            IRepository<Book> bookRepository,
            IRepository<User> userRepository)
        {
            this.context = context;
            this.BookRepository = bookRepository;
            this.UserRepository = userRepository;
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
