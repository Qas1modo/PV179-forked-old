using System;
using Infrastructure.EFCore;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Infrastrucure.EFCore.Repository;
using Castle.Core.Resource;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.EFCore.Test.Repository
{
    public class RepositoryTest : Tests
    {
        private BookReservationDbContext dbContext;

        private readonly Author dummyAuthorGet = new Author { Id = 1, Name = "Richard Dreveny" };
        private Author dummyAuthorUpdate = new Author { Id = 2, Name = "Peter Dreveny" };
        private readonly Author dummyAuthorDeleteById = new Author { Id = 3, Name = "Martin Dreveny" };
        private readonly Author dummyAuthorDeleteByEntity = new Author { Id = 4, Name = "Juraj Dreveny" };

        public override void InitDatabase()
        {
            dbContext = new BookReservationDbContext(dbContextOptions);

            dbContext.Authors.Add(dummyAuthorGet);
            dbContext.Authors.Add(dummyAuthorUpdate);
            dbContext.Authors.Add(dummyAuthorDeleteById);
            dbContext.Authors.Add(dummyAuthorDeleteByEntity);
            dbContext.SaveChanges();
        }

        [Fact]
        public void PassingInsertTest()
        {
            Author dummyAuthorInsert = new Author { Id = 9, Name = "Matko Kubko" };

            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Insert(dummyAuthorInsert);
            dbContext.SaveChanges();

            Author retrievedDummyAuthor = dbContext.Authors.Single(author => author.Id == dummyAuthorInsert.Id);
            Assert.True(retrievedDummyAuthor.Name.Equals(dummyAuthorInsert.Name));
        }

        [Fact]
        public void PassingGetTest()
        {
            var efRepository = new EFGenericRepository<Author>(dbContext);
            var result = efRepository.GetByID(dummyAuthorGet.Id);

            Assert.True(result.Name.Equals(dummyAuthorGet.Name));
        }

        [Fact]
        public void PassingUpdateTest()
        {
            dummyAuthorUpdate.Name = "Nove meno";

            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Update(dummyAuthorUpdate);
            dbContext.SaveChanges();


            Author updatedDummyAuthor = dbContext.Authors.Single(author => author.Id == dummyAuthorUpdate.Id);
            Assert.True(updatedDummyAuthor.Name.Equals(dummyAuthorUpdate.Name));
        }

        [Fact]
        public void PassingDeleteByIdTest()
        {
            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Delete(dummyAuthorDeleteById.Id);
            dbContext.SaveChanges();

            Author retrievedDummyAuthor = dbContext.Authors.SingleOrDefault(author => author.Id == dummyAuthorDeleteById.Id);

            Assert.True(retrievedDummyAuthor == null);
        }

        [Fact]
        public void PassingDeleteByEntityTest()
        {
            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Delete(dummyAuthorDeleteByEntity);
            dbContext.SaveChanges();

            Author retrievedDummyAuthor = dbContext.Authors.SingleOrDefault(author => author.Id == dummyAuthorDeleteByEntity.Id);
            Assert.True(retrievedDummyAuthor == null);
        }
    }
}
