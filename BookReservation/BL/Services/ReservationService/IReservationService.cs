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
        void CreateReservation(ReservationDto rentDto);

        bool ChangeState(int reservationId, RentState newState, int userId);

        QueryResultDto<ReservationDetailDto> ShowReservations(int userId,
            int pageNumber,
            RentState state);
    }
}
