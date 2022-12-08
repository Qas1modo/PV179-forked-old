using System;
using BL.DTOs;

namespace WebAppMVC.Models
{
    public class BookDetailIndexModel
    {
        public BookBasicInfoDto bookInfo { get; set; }

        public IEnumerable<ReviewDetailDto> reviews { get; set; }
    }
}

