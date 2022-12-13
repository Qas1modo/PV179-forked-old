using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class ReservationDto
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime ReservedAt { get; set; }

        public DateTime? RentedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public DateTime? CanceledAt { get; set; }

        public int LoanPeriod { get; set; }

        public RentState State { get; set; }
    }
}
