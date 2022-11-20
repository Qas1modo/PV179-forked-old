using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
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

namespace BL.Services.ReservationServ
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper mapper;
        private readonly IUoWReservation uow;

        public ReservationService(IUoWReservation uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public void CreateReservation(ReservationDto rentDto)
        {
            uow.ReservationRepository.Insert(mapper.Map<Reservation>(rentDto));
            uow.Commit();
        }

        public void ChangeState(int reservationId, RentState newState)
        {
            Reservation rent = uow.ReservationRepository.GetByID(reservationId);
            if (newState == RentState.Reserved)
            {
                rent.State = newState;
                rent.ReservedAt = new DateTime();
            }
            else if (newState == RentState.Returned) 
            {
                rent.State = newState;
                rent.ReturnedAt = new DateTime();
            }
            else if (newState == RentState.Active)
            {
                rent.State = newState;
                rent.RentedAt = new DateTime();
            } 
            else
            {
                rent.State = newState;
            }
            uow.ReservationRepository.Update(rent);
            uow.Commit();
        }

        public IEnumerable<ReservationDetailDto> ShowReservations(int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            return mapper.Map<IEnumerable<ReservationDetailDto>>(user.Rents);
        }
    }
}
