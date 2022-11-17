using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
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

namespace BL.Services.Reservation
{
    public class RentService : IRentService
    {
        private readonly IMapper mapper;
        private readonly IUoWReservation uow;

        public RentService(IUoWReservation uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public void CreateReservation(RentDto rentDto)
        {
            uow.RentRepository.Insert(mapper.Map<Rent>(rentDto));
            uow.Commit();
        }

        public void CancelReservation(int reservationId)
        {
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Canceled;
            uow.RentRepository.Update(rent);
            uow.Commit();
        }

        public void ReservationTaken(int reservationId)
        {
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Active;
            rent.RentedAt = new DateTime();
            uow.RentRepository.Update(rent);
            uow.Commit();
        }

        public void BookReturned(int reservationId)
        {
            Rent rent = uow.RentRepository.GetByID(reservationId);
            rent.State = RentState.Returned;
            rent.ReturnedAt = new DateTime();
            uow.RentRepository.Update(rent);
            uow.Commit();
        }

        public IEnumerable<RentDetailDto> ShowRents(int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            // WHY NOT ? --> return mapper.Map<RentDetailDto>(user.Rents);
            // if it does not work with already configured mapping... maybe
            // CreateMap<List<Rent>, List<RentDetailDto>>().ReverseMap() ?
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
