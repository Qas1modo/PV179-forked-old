using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class ReviewDetailDto
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public string? Description { get; set; }
    }
}
