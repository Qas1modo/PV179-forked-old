using DAL.Models;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using DAL.Enums;
using Infrastructure.Query;

namespace BL.Services.ReservationServ
{
    public interface IReservationService
    {
        void CreateReservation(ReservationDto rentDto,
            RentState state = RentState.Reserved,
            bool commit = false);

        Task<bool> ChangeState(int reservationId, RentState newState,
            int userId, Reservation? reservation = null, bool commit = false);

        QueryResultDto<ReservationDetailDto> ShowReservations(int userId,
            int pageNumber,
            RentState state);
    }
}
