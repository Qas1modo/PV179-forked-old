using System;
using System.Collections.Generic;
using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.Services.CRUD;
using BL.Services.StockService;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;

namespace BL.Services.CartItem
{
	public class CartItemService : ICartItemService
	{
        private readonly IMapper mapper;
        private readonly BookReservationDbContext context;

        public CartItemService(BookReservationDbContext context, IMapper mapper)
		{
            this.mapper = mapper;
            this.context = context;
        }

        public void AddItem(CartItemDto itemDto)
        {
            using IUoWCartItem uow = new EFUoWCartItem(context);
            uow.CartItemRepository.Insert(mapper.Map<DAL.Models.CartItem>(itemDto));
            uow.Commit();
        }

        public void RemoveItem(object id)
        {
            using IUoWCartItem uow = new EFUoWCartItem(context);
            uow.CartItemRepository.Delete(id);
            uow.Commit();
        }

        public void EmptyCart(object userId)
        {
            using IUoWCartItems uow = new EFUoWCartItems(context);
            User user = uow.UserRepository.GetByID(userId);
            foreach (var cartItem in user.CartItems)
            {
                uow.CartItemRepository.Delete(cartItem.Id);
            }
            uow.Commit();
        }

        public IEnumerable<CartItemDetailDto> GetCartItems(int userId)
        {
            using IUoWCartItems uow = new EFUoWCartItems(context);
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

