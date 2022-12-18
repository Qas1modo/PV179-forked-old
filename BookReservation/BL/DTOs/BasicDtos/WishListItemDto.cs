using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class WishListItemDto
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime AddedAt { get; set; }
    }
}
