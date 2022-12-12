using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.CartItemServ
{
    public interface ICartItemService
    {
        Task AddItem(CartItemDto itemDto);

        Task RemoveItem(int id);

        Task EmptyCart(int userId);

        Task<IEnumerable<CartItemDetailDto>> GetCartItems(int userId);
    }
}

