using AutoMapper;
using BL.Services.ReservationService;
using DAL.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tests.Services
{
    public class ReservationServiceTests : AbstractTest
    {
        private readonly Mock<IMapper> mapper;
        private readonly Mock<IUoWReservation> uow;

        public ReservationServiceTests()
        {
            mapper = new Mock<IMapper>();
            uow = new Mock<IUoWReservation>();
        }

        // this would be the same for others if good
        [Fact]
        public void BookReturnTestPass()
        {
            // test null or non-existing input ? --> not really a test .. just checking mocked vals
            uow.Setup(x => x.ReservationRepository.GetByID(rent.Id)).Returns(rent).Verifiable();
            uow.Setup(x => x.ReservationRepository.Update(rent)).Verifiable();
            uow.Setup(x => x.Commit()).Verifiable();

            // Preconditions
            rent.ReturnedAt = null;
            rent.State = DAL.Enums.RentState.Active;

            var service = new ReservationService(uow.Object, mapper.Object);

            service.ChangeState(rent.Id, DAL.Enums.RentState.Returned);

            // Verify that setups have been called within service
            uow.Verify();

            Assert.True(rent.State == DAL.Enums.RentState.Returned);
            Assert.NotNull(rent.ReturnedAt);
        }

    }
}
