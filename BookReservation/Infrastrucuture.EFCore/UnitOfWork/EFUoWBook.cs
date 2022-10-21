using DAL.Models;
using DAL;
using Infrastructure.UnitOfWork;
using Infrastrucure.Repository;
using Infrastrucure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.UnitOfWork
{
    public class EFUoWBook : IUoWBook
    {
        private IRepository<Author> authorRepository;
        private IRepository<Book> bookRepository;
        private IRepository<Genre> genreRepository;

        public EFUoWBook(DbContextOptions<BookReservationDbContext> options)
        {
            Context = new(options);
        }

        public EFUoWBook()
        {
            Context = new();
        }

        public BookReservationDbContext Context { get; }

        public IRepository<Author> AuthorRepository 
        { 
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new EFGenericRepository<Author>(Context);
                }
                return authorRepository;
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new EFGenericRepository<Book>(Context);
                }
                return bookRepository;
            }
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
