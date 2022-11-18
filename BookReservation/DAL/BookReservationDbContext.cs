using DAL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class BookReservationDbContext : DbContext
    {
        private readonly string _connectionString = "";
        private const string _dbName = "BookReservationDB";

        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Reservation> Rents { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookReservationDbContext()
        {
            _connectionString = $"Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={_dbName};Trusted_Connection=True;";
        }

        public BookReservationDbContext(DbContextOptions<BookReservationDbContext> options) : base(options)
        {
            _connectionString = $"Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={_dbName};Trusted_Connection=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
