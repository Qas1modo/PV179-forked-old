using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class RentDto
    {
        public UserDto User { get; set; }

        public BookDto Book { get; set; }

        public DateTime ReservedAt { get; set; }

        public DateTime? RentedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public int LoanPeriod { get; set; }

        public decimal Price { get; set; }

        public RentState State { get; set; }
    }
}
