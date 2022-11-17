using System;
using BL.DTOs;

namespace BL.Services.CartItems
{
	public interface ICartItemsService
	{
        public void EmptyCart(int userId);

        public IEnumerable<CartItemDetailDto> GetCartItems(int userId);
    }
}

