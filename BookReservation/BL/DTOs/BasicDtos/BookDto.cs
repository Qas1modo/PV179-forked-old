using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class BookDto
    {
        [StringLength(64)]
        public string Name { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }


        [Range(0, int.MaxValue)]
        public int Total { get; set; }

        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        public bool Deleted { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
