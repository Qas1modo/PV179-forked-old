using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class RegistrationDto
    {
        public string Password { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StNumber { get; set; }

        public int ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateOnly BirthDate { get; set; }
    }
}
