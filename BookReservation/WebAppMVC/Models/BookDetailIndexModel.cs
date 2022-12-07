using System;
using BL.DTOs;

namespace WebAppMVC.Models
{
    public class BookDetailIndexModel
    {
        public BookBasicInfoDto bookInfo;

        public IEnumerable<ReviewDetailDto> reviews;
    }
}

