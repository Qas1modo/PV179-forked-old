using BL.DTOs.BasicDtos;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class AdminChangeBookModel
    {

        [Required, StringLength(64)]
        public string Name { get; set; }

        [StringLength(64)]
        public string GenreName { get; set; }

        [StringLength(64)]
        public string AuthorName { get; set; }

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
