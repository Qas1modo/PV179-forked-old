using DAL.Models;
using DAL;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWAuthor : IUoWAuthor
    {
        public IRepository<Author> AuthorRepository { get; }

        private readonly BookReservationDbContext context;

        public EFUoWAuthor(BookReservationDbContext context,
            IRepository<Author> authorRepository)
        {
            this.context = context;
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
