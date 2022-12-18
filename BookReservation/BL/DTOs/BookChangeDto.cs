using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class BookChangeDto
    {
        [Required, StringLength(64)]
        public string Name { get; set; }

        [StringLength(64)]
        public string NewGenreName { get; set; }

        [StringLength(64)]
        public string NewAuthorName { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Total { get; set; }
    }
}
