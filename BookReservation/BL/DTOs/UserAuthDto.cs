using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Group Group { get; set; }
    }
}
