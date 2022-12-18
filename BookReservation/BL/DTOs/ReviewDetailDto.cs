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

        public int Id { get; set; }

        public int Score { get; set; }
        
        public int UserId { get; set; }

        public DateTime AddedAt { get; set; }

        public string? Description { get; set; }
    }
}
