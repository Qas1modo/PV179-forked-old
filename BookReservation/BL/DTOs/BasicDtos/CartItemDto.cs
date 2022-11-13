using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class CartItemDto
    {
        public UserDto User { get; set; }

        public BookDto Book { get; set; }
    }
}
