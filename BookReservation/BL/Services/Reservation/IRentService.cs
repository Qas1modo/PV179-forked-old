using DAL.Models;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Reservation
{
    public interface IRentService
    {
        public void CreateReservation(RentDto rentDto);

        public void CancelReservation(object reservationId);

        public void ReservationTaken(object reservationId);

        public void BookReturned(object reservationId);
    }
}
