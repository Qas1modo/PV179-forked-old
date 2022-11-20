using AutoMapper;
using BL.Services.ReservationService;
using DAL.Enums;
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

        private void SetupUoWForChangeStateTest()
        {
            uow.Setup(x => x.ReservationRepository.GetByID(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    if (id != rent.Id)
                    {
                        throw new Exception();
                    }

                    return rent;
                })
                .Verifiable();

            uow.Setup(x => x.ReservationRepository.Update(rent)).Verifiable();
            uow.Setup(x => x.Commit()).Verifiable();

            // Preconditions
            rent.ReturnedAt = null;
            rent.RentedAt = null;
            rent.State = DAL.Enums.RentState.Active;
        }

        [Fact(DisplayName = "Return book test")]
        public void ChangeStateTestPassingReturnBook()
        {
            SetupUoWForChangeStateTest();

            var service = new ReservationService(uow.Object, mapper.Object);

            service.ChangeState(rent.Id, DAL.Enums.RentState.Returned);

            // Verify that setups have been called within service
            uow.Verify();

            Assert.True(rent.State == RentState.Returned);
            Assert.NotNull(rent.ReturnedAt);
        }

        
        [Fact(DisplayName = "NonExisting ID")]
        public void ChangeStateTestNonExistingID()
        {
            SetupUoWForChangeStateTest();

            var service = new ReservationService(uow.Object, mapper.Object);

            Assert.Throws<Exception>(() => service.ChangeState(42, RentState.Returned));
        }


        [Fact(DisplayName = "Rent book test")]
        public void ChangeStateTestRentBook()
        {
            SetupUoWForChangeStateTest();


            var service = new ReservationService(uow.Object, mapper.Object);

            service.ChangeState(rent.Id, RentState.Active);

            Assert.True(rent.State == RentState.Active);
            Assert.NotNull(rent.RentedAt);
            Assert.Null(rent.ReturnedAt); // unchanged!
        }


    }
}
