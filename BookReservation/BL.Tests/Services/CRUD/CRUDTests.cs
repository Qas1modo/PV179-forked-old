using System;
using Infrastructure.Repository;
using DAL.Models;
using AutoMapper;
using BL.Services.CRUD;
using BL.DTOs.BasicDtos;
using FluentAssertions;

namespace BL.Tests.Services.CRUD
{
	public class CRUDTests
	{
        Mock<IRepository<Author>> _authorRepositoryMock;
        Mock<IMapper> _mapperMock;

        public CRUDTests()
		{
            _authorRepositoryMock = new Mock<IRepository<Author>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public void PassingAuthorCRUDCreateTest()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            AuthorDto author = new()
            {
                Name = "meno"
            };


            service.Create<AuthorDto>(author);

            _authorRepositoryMock.Verify(x => x.Insert(It.IsAny<Author>()), Times.Once());
        }

        [Fact]
        public void FailingAuthorCRUDCreateTest()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            AuthorDto mockedAuthor = null;

            var action = () => service.Create<AuthorDto>(mockedAuthor);

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void PassingAuthorCRUDGetTest()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            AuthorDto expected = new()
            {
                Name = "meno",
                Id = 1
            };

            Author mockedAuthor = new();

            _authorRepositoryMock
                .Setup(x => x.GetByID(expected.Id))
                .Returns(mockedAuthor);

            _mapperMock
                .Setup(x => x.Map<AuthorDto>(mockedAuthor))
                .Returns(expected);

            var actual = service.GetById<AuthorDto>(1);

            actual.Should().Be(expected);

            _authorRepositoryMock.Verify(x => x.GetByID(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void PassingAuthorCRUDUpdateTestPassing()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            AuthorDto author = new()
            {
                Name = "meno"
            };

            service.Update<AuthorDto>(author);

            _authorRepositoryMock.Verify(x => x.Update(It.IsAny<Author>()), Times.Once());
        }

        [Fact]
        public void PassingAuthorCRUDRemoveByIdTestPassing()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            service.DeleteById(1);

            _authorRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void PassingAuthorCRUDRemoveByEntityTest()
        {
            var service = new CRUDService<Author>(_authorRepositoryMock.Object, _mapperMock.Object);

            AuthorDto author = new()
            {
                Name = "meno"
            };

            service.DeleteByEntity<AuthorDto>(author);

            _authorRepositoryMock.Verify(x => x.Delete(It.IsAny<Author>()), Times.Once());
        }
    }
}

