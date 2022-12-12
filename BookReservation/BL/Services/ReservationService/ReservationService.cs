using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using DAL;
using DAL.Enums;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.Query;
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
        private readonly IQuery<Reservation> query;

        public ReservationService(IUoWReservation uow,
            IMapper mapper,
            IQuery<Reservation> query)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.query = query;
        }

        public void CreateReservation(ReservationDto rentDto)
        {
            uow.ReservationRepository.Insert(mapper.Map<Reservation>(rentDto));
            uow.CommitAsync();
        }

        public bool ChangeState(int reservationId, RentState newState, int userId = -1)
        {
            Reservation rent = uow.ReservationRepository.GetByID(reservationId);
            if (userId != -1 && userId != rent.UserId)
            {
                return false;
            }
            switch(newState)
            {
                case RentState.Reserved:
                    rent.ReservedAt = new DateTime();
                    break;
                case RentState.Returned:
                    rent.ReturnedAt = new DateTime();
                    break;
                case RentState.Active:
                    rent.RentedAt = new DateTime();
                    break;
            }
            rent.State = newState;
            uow.ReservationRepository.Update(rent);
            uow.CommitAsync();
            return true;
        }

        public QueryResultDto<ReservationDetailDto> ShowReservations(int userId,
            int pageNumber,
            RentState state)
        {
            query.Where<int>(x => x == userId, "UserId");
            query.Where<RentState>(x => x.Equals(state), "State");
            query.OrderBy<DateTime>("ReservedAt", false);
            query.Page(pageNumber, 10);
            var result = query.Execute();
            return mapper.Map<QueryResult<Reservation>, QueryResultDto<ReservationDetailDto>>(result);
        }
    }
}
