using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.CartItemService
{
	public interface ICartItemService
	{
        void AddItem(CartItemDto itemDto);

        void RemoveItem(int id);

        void EmptyCart(int userId);

        IEnumerable<CartItemDetailDto> GetCartItems(int userId);
    }
}

