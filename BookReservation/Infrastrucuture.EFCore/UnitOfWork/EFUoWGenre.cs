using System;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Repository;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;

namespace Infrastructure.EFCore.UnitOfWork
{
	public class EFUoWGenre : IUoWGenre
    {
        private IRepository<Genre> genreRepository;

        public BookReservationDbContext Context { get; }

        public EFUoWGenre(BookReservationDbContext context)
		{
            Context = context;
        }

        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new EFGenericRepository<Genre>(Context);
                }
                return genreRepository;
            }
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

