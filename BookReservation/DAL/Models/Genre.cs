using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Genre : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }
    }
}
