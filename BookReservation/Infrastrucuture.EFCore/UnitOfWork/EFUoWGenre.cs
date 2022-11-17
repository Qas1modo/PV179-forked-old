using DAL;
using DAL.Models;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWGenre : IUoWGenre

    {
        public IRepository<Genre> GenreRepository { get; }

        private BookReservationDbContext context;

        public EFUoWGenre(BookReservationDbContext context, IRepository<Genre> genreRepository)
        {
            this.context = context;
            GenreRepository = genreRepository;
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

