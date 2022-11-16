using System;
using BL.DTOs;

namespace BL.Services.CartItemsService
{
	public interface ICartItemsService
	{
        public void EmptyCart(object userId);

        public IEnumerable<CartItemDetailDto> GetCartItems(int userId);
    }
}

