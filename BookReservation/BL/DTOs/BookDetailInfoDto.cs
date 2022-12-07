using System;
using BL.DTOs.BasicDtos;

namespace BL.DTOs
{
    public class BookDetailInfoDto
    {
        public int Id { get; set; }

        public AuthorDto Author { get; set; }

        public GenreDto Genre { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}

