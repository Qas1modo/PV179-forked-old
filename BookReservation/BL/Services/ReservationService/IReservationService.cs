using DAL.Models;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using DAL.Enums;

namespace BL.Services.ReservationService
{
    public interface IReservationService
    {
        public void CreateReservation(ReservationDto rentDto);

        public void ChangeState(int reservationId, RentState newState);

        public IEnumerable<ReservationDetailDto> ShowReservations(int userId);
    }
}
