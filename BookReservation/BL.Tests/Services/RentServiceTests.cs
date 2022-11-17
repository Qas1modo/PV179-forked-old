using AutoMapper;
using BL.Services.Reservation;
using DAL.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tests.Services
{
    public class RentServiceTests : AbstractTest
    {
        private Mock<IMapper> mapper;
        private Mock<IUoWReservation> uow;

        public RentServiceTests()
        {
            mapper = new Mock<IMapper>();
            uow = new Mock<IUoWReservation>();
        }

        // this would be the same for others if good
        [Fact]
        public void BookReturnTestPass()
        {
            // test null or non-existing input ? --> not really a test .. just checking mocked vals
            uow.Setup(x => x.RentRepository.GetByID(rent.Id)).Returns(rent).Verifiable();
            uow.Setup(x => x.RentRepository.Update(rent)).Verifiable();
            uow.Setup(x => x.Commit()).Verifiable();

            // Preconditions
            rent.ReturnedAt = null;
            rent.State = DAL.Enums.RentState.Active;

            var service = new RentService(uow.Object, mapper.Object);

            service.BookReturned(rent.Id);

            // Verify that setups have been called within service
            uow.Verify();

            Assert.True(rent.State == DAL.Enums.RentState.Returned);
            Assert.NotNull(rent.ReturnedAt);
        }

    }
}
