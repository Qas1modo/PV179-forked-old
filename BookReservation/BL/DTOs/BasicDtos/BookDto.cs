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

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public int Stock { get; set; }

        public int Total { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
