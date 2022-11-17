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

        public void CancelReservation(int reservationId);

        public void ReservationTaken(int reservationId);

        public void BookReturned(int reservationId);
    }
}
