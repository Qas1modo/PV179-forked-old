using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class AddressDto
    {
        public UserDto User { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StNumber { get; set; }

        public int ZipCode { get; set; }
    }
}
