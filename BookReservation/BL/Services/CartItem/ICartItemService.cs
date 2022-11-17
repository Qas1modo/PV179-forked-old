using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.CartItem
{
	public interface ICartItemService
	{
        public void AddItem(CartItemDto itemDto);

        public void RemoveItem(object id);
    }
}

