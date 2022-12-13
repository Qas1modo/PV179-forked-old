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

        public void CreateReservation(ReservationDto rentDto, bool commit = false)
        {
            rentDto.State = RentState.Reserved;
            rentDto.ReservedAt = new DateTime();
            uow.ReservationRepository.Insert(mapper.Map<Reservation>(rentDto));
            if (commit) uow.CommitAsync(); 
        }

        public async Task<int> ChangeState(int reservationId, RentState newState,
            int userId = -1, bool commit = false)
        {
            Reservation rent = await uow.ReservationRepository.GetByID(reservationId);
            if (userId != -1 && userId != rent.UserId)
            {
                return -1;
            }
            switch (newState)
            {
                case RentState.Expired:
                    if (rent.State != RentState.Reserved) return -1;
                    rent.CanceledAt = DateTime.Now;
                    break;
                case RentState.Canceled:
                    if (rent.State != RentState.Reserved) return -1;
                    rent.CanceledAt = DateTime.Now;
                    break;
                case RentState.Reserved:
                    if (rent.State != RentState.Expired) return -1;
                    rent.ReservedAt = DateTime.Now;
                    break;
                case RentState.Returned:
                    if (rent.State != RentState.Active) return -1;
                    rent.ReturnedAt = DateTime.Now;
                    break;
                case RentState.Active:
                    if (rent.State != RentState.Reserved) return -1;
                    rent.RentedAt = DateTime.Now;
                    break;
            }
            rent.State = newState;
            uow.ReservationRepository.Update(rent);
            if (commit) await uow.CommitAsync();
            return rent.BookId;
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
