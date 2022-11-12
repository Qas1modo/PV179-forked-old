using System;
using Infrastructure.EFCore;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EFCore.Repository;
using Castle.Core.Resource;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.EFCore.Test.Repository
{
    public class RepositoryTest : Tests
    {
        private readonly Dictionary<string, Author> map = new Dictionary<string, Author>
        {
            ["get"] = new Author { Id = 10, Name = "Richard Dreveny" },
            ["update"] = new Author { Id = 20, Name = "Peter Dreveny" },
            ["deleteById"] = new Author { Id = 30, Name = "Martin Dreveny" },
            ["deleteByEntity"] = new Author { Id = 40, Name = "Juraj Dreveny" },
        };

        public override void InitDatabase()
        {
            foreach (var item in map.Values)
            {
                dbContext.Add(item);
            }

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
            var result = efRepository.GetByID(map["get"].Id);

            Assert.True(result.Name.Equals(map["get"].Name));
        }

        [Fact]
        public void PassingUpdateTest()
        {
            map["update"].Name = "Nove meno";

            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Update(map["update"]);
            dbContext.SaveChanges();

            Author updatedDummyAuthor = dbContext.Authors.Single(author => author.Id == map["update"].Id);
            Assert.True(updatedDummyAuthor.Name.Equals(map["update"].Name));
        }

        [Fact]
        public void PassingDeleteByIdTest()
        {
            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Delete(map["deleteById"].Id);
            dbContext.SaveChanges();

            Author? retrievedDummyAuthor1 = dbContext.Authors.SingleOrDefault(author => author.Id == map["deleteById"].Id);
            Assert.True(retrievedDummyAuthor1 == null);
        }

        [Fact]
        public void PassingDeleteByEntityTest()
        {
            var efRepository = new EFGenericRepository<Author>(dbContext);
            efRepository.Delete(map["deleteByEntity"]);
            dbContext.SaveChanges();

            Author? retrievedDummyAuthor = dbContext.Authors.SingleOrDefault(author => author.Id == map["deleteByEntity"].Id);
            Assert.True(retrievedDummyAuthor == null);
        }
    }
}
