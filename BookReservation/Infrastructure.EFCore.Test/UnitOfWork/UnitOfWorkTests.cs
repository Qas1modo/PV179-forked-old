using System;
using DAL.Models;
using DAL.Enums;
using DAL;
using Microsoft.EntityFrameworkCore;
using Infrastrucure.EFCore.Repository;
using Infrastrucuture.EFCore.UnitOfWork;
using Castle.Core.Resource;
using System.Linq;


namespace Infrastructure.EFCore.Test.UnitOfWork
{
    public class UnitOfWorkTests
    {
        private readonly DbContextOptions<BookReservationDbContext> dbContextOptions;
        private readonly Author dummyAuthor = new() { Id = 1, Name = "Richard Dreveny" };
        private readonly User dummyUser = new()
        {
            Id = 2,
            AddressId = 2,
            Name = "Peter Marcin",
            Email = "peter123@mail.com",
            Password = "jjpjpkf",
            Salt = "dkpafjapfjpak",
            Phone = "+421911999222",
            BirthDate = new DateTime(1980, 3, 1),
            Group = Group.Employee,
            Picture = "www.pictureofemployee.com",
        };

        public UnitOfWorkTests()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Options for in-memory db
            dbContextOptions = new DbContextOptionsBuilder<BookReservationDbContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            InitDatabase();
            
        }

        [Fact]
        public void PassingTransactionTest()
        {
            Author dummyAuthorInsert = new Author { Id = 9, Name = "Matko Kubko" };
            // Used in update
            string newName = "Chad Chad";

            var efUnitOfWork = new EFUnitOfWork(dbContextOptions);
            var authorRepo = efUnitOfWork.AuthorRepository;
            var userRepo = efUnitOfWork.UserRepository;

            // Insert new Author and Update user
            authorRepo.Insert(dummyAuthorInsert);
            var user = userRepo.GetByID(dummyUser.Id);

            // asert user not null or exists ?
            // update user
            user.Name = newName;

            efUnitOfWork.Commit().Wait();

            efUnitOfWork = new EFUnitOfWork(dbContextOptions);
            authorRepo = efUnitOfWork.AuthorRepository;
            userRepo = efUnitOfWork.UserRepository;

            Author retrievedDummyAuthor = authorRepo.GetByID(dummyAuthorInsert.Id);
            User editedUser = userRepo.GetByID(dummyUser.Id);

           Assert.True(retrievedDummyAuthor.Name.Equals(dummyAuthorInsert.Name));
           Assert.True(editedUser.Name.Equals(newName));
        }

        [Fact]
        public void NonCommitedTransactionTest()
        {
            // How to fail commit on prupose ?

            Author dummyAuthorInsert = new Author { Id = 9, Name = "Matko Kubko" };
            // Used in update
            string newName = "Chad Chad";

            var efUnitOfWork = new EFUnitOfWork(dbContextOptions);
            var authorRepo = efUnitOfWork.AuthorRepository;
            var userRepo = efUnitOfWork.UserRepository;

            // Insert new Author and Update user
            authorRepo.Insert(dummyAuthorInsert);
            var user = userRepo.GetByID(dummyUser.Id);

            // asert user not null or exists ?
            // update user
            user.Name = newName;

            efUnitOfWork = new EFUnitOfWork(dbContextOptions);
            authorRepo = efUnitOfWork.AuthorRepository;
            userRepo = efUnitOfWork.UserRepository;

            Author retrievedDummyAuthor = authorRepo.GetByID(dummyAuthorInsert.Id);
            User editedUser = userRepo.GetByID(dummyUser.Id);

            Assert.Null(retrievedDummyAuthor);
            Assert.False(editedUser.Name.Equals(newName));
        }

        private void InitDatabase()
        {
            var dbContext = new BookReservationDbContext(dbContextOptions);

            dbContext.Authors.Add(dummyAuthor);
            dbContext.Users.Add(dummyUser);

            dbContext.SaveChanges();
        }
    }
}
