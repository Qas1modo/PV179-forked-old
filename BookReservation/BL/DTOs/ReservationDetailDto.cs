using BL.DTOs.BasicDtos;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public DateTime ReservedAt { get; set; }

        public DateTime? RentedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public int LoanPeriod { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public RentState State { get; set; }
    }
}
