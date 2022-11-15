using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.ReservationService
{
    public interface IRentService
    {
        public void CreateReservation(int bookId, int userId, int loanPeriod, decimal price);

        public void CancelReservation(object reservationId);

        public void ReservationTaken(object reservationId);

        public void BookReturned(object reservationId);
    
    }
}
