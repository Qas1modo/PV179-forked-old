using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class BookBasicInfoDto
    {
        public int Id { get; set; }

        public AuthorDto Author { get; set; }
        
        public GenreDto Genre { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

    }
}
