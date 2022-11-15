using AutoMapper;
using BL.DTOs;
using BL.QueryObjects;
using DAL;
using DAL.Enums;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.ReservationService
{
    public class RentService : IRentService
    {
        private readonly BookReservationDbContext context;
        private readonly IMapper mapper;

        public RentService(BookReservationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateReservation(int bookId, int userId, int loanPeriod, decimal price)
        {
            using IUoWReservation uow = new EFUoWReservation(context);
            Rent rent = new(){ BookId = bookId, LoanPeriod = loanPeriod, Price = price, ReservedAt = new DateTime(), State = RentState.Reserved, UserId = userId };
            uow.RentRepository.Insert(rent);
            uow.Commit();
        }

        public void CancelReservation(object reservationId)
        {
            using IUoWReservation uow = new EFUoWReservation(context);
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Canceled;
            uow.RentRepository.Update(rent);
            uow.Commit();

        }

        public void ReservationTaken(object reservationId)
        {
            using IUoWReservation uow = new EFUoWReservation(context);
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Active;
            rent.RentedAt = new DateTime();
            uow.RentRepository.Update(rent);
            uow.Commit();
        }

        public void BookReturned(object reservationId)
        {
            using IUoWReservation uow = new EFUoWReservation(context);
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Returned;
            rent.ReturnedAt = new DateTime();
            uow.RentRepository.Update(rent);
            uow.Commit();
        }

        public IEnumerable<RentDetailDto> ShowRents(object userId)
        {
            using IUoWReservation uow = new EFUoWReservation(context);
            User user = uow.UserRepository.GetByID(userId);
            IEnumerable<RentDetailDto> result = new List<RentDetailDto>();
            foreach (var rent in user.Rents)
            {
                Book book = uow.BookRepository.GetByID(rent.BookId);
                RentDetailDto item = mapper.Map<RentDetailDto>(rent);
                item.Name = book.Name;
                result = result.Append(item);
            }
            return result;
        }
    }
}
