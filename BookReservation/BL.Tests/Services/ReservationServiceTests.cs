using AutoMapper;
using BL.Services.ReservationServ;
using DAL.Enums;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.Query;
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
        private readonly Mock<IQuery<Reservation>> query;

        public ReservationServiceTests()
        {
            mapper = new Mock<IMapper>();
            uow = new Mock<IUoWReservation>();
            query = new Mock<IQuery<Reservation>>();
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
            uow.Setup(x => x.CommitAsync()).Verifiable();

            // Preconditions
            rent.ReturnedAt = null;
            rent.RentedAt = null;
            rent.State = RentState.Active;
        }

        [Fact(DisplayName = "Return book test")]
        public void ChangeStateTestPassingReturnBook()
        {
            SetupUoWForChangeStateTest();

            var service = new ReservationService(uow.Object, mapper.Object, (IQuery<Reservation>)query);

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

            var service = new ReservationService(uow.Object, mapper.Object, (IQuery<Reservation>)query);

            Assert.Throws<Exception>(() => service.ChangeState(42, RentState.Returned));
        }


        [Fact(DisplayName = "Rent book test")]
        public void ChangeStateTestRentBook()
        {
            SetupUoWForChangeStateTest();


            var service = new ReservationService(uow.Object, mapper.Object, (IQuery<Reservation>)query);

            service.ChangeState(rent.Id, RentState.Active);

            Assert.True(rent.State == RentState.Active);
            Assert.NotNull(rent.RentedAt);
            Assert.Null(rent.ReturnedAt); // unchanged!
        }


    }
}
