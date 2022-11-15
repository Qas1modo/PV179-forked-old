using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class CartItemDetailDto
    {
        public AuthorDto Author { get; set; }

        public GenreDto Genre { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public int LoanPeriod { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
