using System;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.Test
{
    public abstract class Tests
    {
        protected readonly DbContextOptions<BookReservationDbContext> dbContextOptions;

        public Tests()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            dbContextOptions = new DbContextOptionsBuilder<BookReservationDbContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            InitDatabase();
        }

        public abstract void InitDatabase();
    }
}

