﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Models
{
    public class Book : BaseEntity
    {
        [Required, MaxLength(64)]
        public string Name { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }

        public int GenreId { get; set; }

        // ErrorMessage = ""?
        [Range(0, int.MaxValue), Required]
        public int Stock { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Total { get; set; }

        [Required, Range(0, 999999)]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Photo { get; set; }

        public bool Deleted { get; set; }

        public virtual List<Reservation> Rents { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
