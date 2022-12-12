using DAL.Models;
using DAL.Enums;
using DAL;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;
using Infrastructure.EFCore.Repository;

namespace Infrastructure.EFCore.Test.UnitOfWork
{
    public class EFUoWChangeUserInfoTests
    {
        private readonly BookReservationDbContext dbContext;
        
        private IRepository<User> userRepository;

        private static readonly User dummyUser = new()
        {
            City = "Madrid",
            Street = "C. De Jorge Juan",
            StNumber = 106,
            ZipCode = 28009,
            Name = "Peter Marcin",
            Email = "peter123@mail.com",
            Password = "jjpjpkf",
            Salt = "dkpafjapfjpak",
            Phone = "+421911999222",
            BirthDate = new DateTime(1980, 3, 1),
            Group = Group.Employee,
        };

        public EFUoWChangeUserInfoTests()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Options for in-memory db
            var options = new DbContextOptionsBuilder<BookReservationDbContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            dbContext = new BookReservationDbContext(options);
            dbContext.Users.Add(dummyUser);

            dbContext.SaveChanges();

            this.userRepository = new EFGenericRepository<User>(dbContext);
        }

        [Fact]
        public void ChangeUserInfoPassingTransactionTest()
        {
            string newName = "Chad Chad";
            string newCity = "Barcelona";
            string newEmail = "a1abcd23@gmail.com";

            using (var efUnitOfWork = new EFUoWUserInfo(dbContext, userRepository))
            {
                var userRepo = efUnitOfWork.UserRepository;

                var user = userRepo.GetByID(dummyUser.Id).Result;
                user.Name = newName;
                user.Email = newEmail;
                user.City = newCity;

                efUnitOfWork.CommitAsync().Wait();

                using (var eF = new EFUoWUserInfo(dbContext, userRepository))
                {
                    userRepo = eF.UserRepository;

                    User editedUser = userRepo.GetByID(dummyUser.Id).Result;

                    Assert.True(editedUser.Name.Equals(newName));
                    Assert.True(editedUser.Email.Equals(newEmail));
                    Assert.True(editedUser.City.Equals(newCity));
                }
            }
        }        
    }
}
