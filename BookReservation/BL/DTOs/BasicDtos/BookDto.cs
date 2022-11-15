using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.BasicDtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public AuthorDto Author { get; set; }

        public int AuthorId { get; set; }

        public virtual GenreDto Genre { get; set; }

        public int Stock { get; set; }

        public int Total { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Photo { get; set; }

        public List<ReviewDto> Reviews { get; set; }
    }
}
