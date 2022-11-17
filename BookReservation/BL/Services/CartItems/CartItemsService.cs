using System;
using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BL.Services.CartItems
{
    public class CartItemsService : ICartItemsService
	{
        private readonly IMapper mapper;
        private readonly IUoWCartItems uow;

        public CartItemsService(IUoWCartItems uow, IMapper mapper)
		{
            this.mapper = mapper;
            this.uow = uow;
		}

        public void EmptyCart(object userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            foreach (var cartItem in user.CartItems)
            {
                uow.CartItemRepository.Delete(cartItem.Id);
            }
            uow.Commit();
        }

        public IEnumerable<CartItemDetailDto> GetCartItems(int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            IEnumerable<CartItemDetailDto> result = new List<CartItemDetailDto>();
            foreach (var cartItem in user.CartItems)
            {
                Book book = uow.BookRepository.GetByID(cartItem.BookId);
                CartItemDetailDto item = mapper.Map<CartItemDetailDto>(book);
                item = mapper.Map(cartItem, item);
                result = result.Append(item);
            }
            return result;
        }
    }
}

