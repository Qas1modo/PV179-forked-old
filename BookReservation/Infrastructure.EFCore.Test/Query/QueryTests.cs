using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;

namespace Infrastructure.EFCore.Test.Query
{
    public class QueryTests
    {
        private readonly BookReservationDbContext Context;
        private Author author1 = new(){ Id = 1, Name = "Sam Hill" };
        private Author author2 = new() { Id = 2, Name = "George" };
        private Author author3 = new() { Id = 3, Name = "Bill" };
        private Author author4 = new() { Id = 4, Name = "TEST" };
        private Author author5 = new() { Id = 5, Name = "Pocket"};
        private Author author6 = new() { Id = 6, Name = "Jimmy"};
        private Author author7 = new() { Id = 7, Name = "Robert" };
        private Author author8 = new() { Id = 8, Name = "Herkules" };
        private Author author9 = new() { Id = 9, Name = "Penny" };
        private Author author10 = new() { Id = 10, Name = "Vasek" };
        private Author author11 = new() { Id = 11, Name = "Pes" };
        public QueryTests()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var dbContextOptions = new DbContextOptionsBuilder<BookReservationDbContext>()
                            .UseInMemoryDatabase(databaseName: myDatabaseName)
                            .Options;

            Context = new BookReservationDbContext(dbContextOptions);
            Context.Add(author1);
            Context.Add(author2);
            Context.Add(author3);
            Context.Add(author4);
            Context.Add(author5);
            Context.Add(author6);
            Context.Add(author7);
            Context.Add(author8);
            Context.Add(author9);
            Context.Add(author10);
            Context.Add(author11);
            Context.SaveChanges();
        }

        [Fact]

        public void TestFindAuthorByName()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<string>(a => a == "Robert", "Name");
            var result = efquery.Execute();
            Assert.True(result.Count() == 1);
            Assert.Equal(author7, result.First());
        }

        [Fact]
        public void TestFindAuthorsStartingP()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<string>(a => a.StartsWith("P"), "Name");
            var result = efquery.Execute();

            var expectedResult = Context.Authors
               .Where(a => a.Name.StartsWith("P"))
               .ToList();
            Assert.True(result.Count() == 3);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestAuthorsWithIdGreaterThan5()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<int>(a => a > 5, "Id");
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
               .Where(a => a.Id > 5)
               .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorsSortAscendingByName()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.OrderBy<string>("Name", true);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .OrderBy(a => a.Name)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorsSortDescendingById()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.OrderBy<int>("Id", false);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .OrderByDescending(a => a.Id)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationThirdPage()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Page(3, 3);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .Skip(6)
                .Take(3)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationNotWholePage()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Page(3, 4);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .Skip(8)
                .Take(3)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationEmptyPage()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Page(4, 4);
            var result = efquery.Execute();

            var ExpectedResult = new List<Author>();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorFilterWithPaggination()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<int>(a => a < 9, "Id");
            efquery.Page(2, 4);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .Where(a => a.Id < 9)
                .Skip(4)
                .Take(4)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorFilterWithOredring()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<int>(a => a < 9, "Id");
            efquery.OrderBy<int>("Id", false);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .Where(a => a.Id < 9)
                .OrderByDescending(a => a.Id)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorEverything()
        {
            var efquery = new EFQuery<Author>(Context);
            efquery.Where<int>(a => a > 3, "Id");
            efquery.OrderBy<string>("Name", true);
            efquery.Page(3, 2);
            var result = efquery.Execute();

            var ExpectedResult = Context.Authors
                .Where(a => a.Id > 3)
                .OrderBy(a => a.Name)
                .Skip(4)
                .Take(2)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }
    }
}

