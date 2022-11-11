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
    public class QueryTests : Tests
    {
        public override void InitDatabase()
        {
            string[] names =
            {
                "Sam Hill",
                "George",
                "Bill",
                "TEST",
                "Pocket",
                "Jimmy",
                "Robert",
                "Herkules",
                "Penny",
                "Vasek",
                "Pes",
            };

            for(int i = 1; i < names.Length + 1; i++)
            {
                dbContext.Add(new Author { Id = i, Name = names[i - 1] });
            }

            dbContext.SaveChanges();
        }

        [Fact]
        public void TestFindAuthorByName()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<string>(a => a.Name == "Robert");
            var result = efquery.Execute();

            var expectedResult = dbContext.Authors
                .Where(a => a.Name == "Robert")
                .ToList();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestFindAuthorWithInvalidId()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<int>(a => a.Id == 13);
            var result = efquery.Execute();

            Assert.False(result.Any());
        }

        [Fact]
        public void TestFindAuthorsStartingP()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<string>(a => a.Name.StartsWith("P"));
            var result = efquery.Execute();

            var expectedResult = dbContext.Authors
               .Where(a => a.Name.StartsWith("P"))
               .ToList();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestAuthorsWithIdGreaterThan5()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<int>(a => a.Id > 5);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
               .Where(a => a.Id > 5)
               .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorsSortAscendingByName()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.OrderBy<string>(a => a.Name);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .OrderBy(a => a.Name)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorsSortDescendingById()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.OrderBy<int>(a => a.Id, false);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .OrderByDescending(a => a.Id)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationThirdPage()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Page(3, 3);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .Skip(6)
                .Take(3)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationNotWholePage()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Page(3, 4);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .Skip(8)
                .Take(3)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuhtorPaginationEmptyPage()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Page(4, 4);
            var result = efquery.Execute();

            var ExpectedResult = new List<Author>();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorFilterWithPaggination()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<int>(a => a.Id < 9);
            efquery.Page(2, 4);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .Where(a => a.Id < 9)
                .Skip(4)
                .Take(4)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorFilterWithOredring()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<int>(a => a.Id < 9);
            efquery.OrderBy<int>(a => a.Id, false);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .Where(a => a.Id < 9)
                .OrderByDescending(a => a.Id)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }

        [Fact]
        public void TestAuthorEverything()
        {
            var efquery = new EFQuery<Author>(dbContext);
            efquery.Where<int>(a => a.Id > 3);
            efquery.OrderBy<string>(a => a.Name, true);
            efquery.Page(3, 2);
            var result = efquery.Execute();

            var ExpectedResult = dbContext.Authors
                .Where(a => a.Id > 3)
                .OrderBy(a => a.Name)
                .Skip(4)
                .Take(2)
                .ToList();

            Assert.Equal(ExpectedResult, result);
        }
    }
}
