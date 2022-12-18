using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class BookBasicInfoDto
    {
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        public AuthorDto Author { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Total { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Stock { get; set; }
    }
}
