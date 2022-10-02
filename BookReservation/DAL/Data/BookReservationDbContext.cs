using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Data
{
    public class BookReservationDbContext : DbContext
    {
        private readonly string _connectionString = "";
        private const string _dbName = "BookReservationDB";


        public DbSet<User> User { get; set; }

        public DbSet<Review> Review { get; set; }
        public DbSet<ReservationItem> ReservationItem { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<PositiveReview> PositiveReview { get; set; }

        public DbSet<NegativeReview> NegativeReview { get; set; }


        public DbSet<Book> Book { get; set; }

        public DbSet<Address> Address { get; set; }


        public BookReservationDbContext()
        {
            // Retrieve string from a file
            _connectionString = $"Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={_dbName};Trusted_Connection=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //     .HasOne(a => a.Address)
            //     .WithOne(u => u.User)
            //     .HasForeignKey<Address>(c => c.Id);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}


            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
