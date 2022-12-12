using System;
using BL.DTOs;

namespace WebAppMVC.Models
{
    public class CartIndexModel
    {
        public IEnumerable<CartItemDetailDto> cartItems { get; set; }
    }
}

