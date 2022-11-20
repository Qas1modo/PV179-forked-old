using DAL.Models;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using DAL.Enums;

namespace BL.Services.ReservationServ
{
    public interface IReservationService
    {
        void CreateReservation(ReservationDto rentDto);

        void ChangeState(int reservationId, RentState newState);

        IEnumerable<ReservationDetailDto> ShowReservations(int userId);
    }
}
