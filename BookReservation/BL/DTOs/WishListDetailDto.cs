﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class WishListDetailDto
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string GenreName { get; set; }

        public string AuthorName { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime AddedAt { get; set; }
    }
}
