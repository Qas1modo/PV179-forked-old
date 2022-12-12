using System;
using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BL.Services.CartItemServ
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper mapper;
        private readonly IUoWCartItem uow;

        public CartItemService(IUoWCartItem uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task AddItem(CartItemDto itemDto)
        {
            uow.CartItemRepository.Insert(mapper.Map<CartItem>(itemDto));
            await uow.CommitAsync();
        }

        public async Task RemoveItem(int id)
        {
            uow.CartItemRepository.Delete(id);
            await uow.CommitAsync();
        }

        public async Task EmptyCart(int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            foreach (var cartItem in user.CartItems)
            {
                uow.CartItemRepository.Delete(cartItem.Id);
            }
            await uow.CommitAsync();
        }

        public async Task<IEnumerable<CartItemDetailDto>> GetCartItems(int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            return mapper.Map<IEnumerable<CartItemDetailDto>>(user.CartItems);
        }
    }
}

