using System;
using System.Collections.Generic;
using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.Services.Stock;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;

namespace BL.Services.CartItem
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

        public void AddItem(CartItemDto itemDto)
        {
            uow.CartItemRepository.Insert(mapper.Map<DAL.Models.CartItem>(itemDto));
            uow.Commit();
        }

        public void RemoveItem(int id)
        {
            uow.CartItemRepository.Delete(id);
            uow.Commit();
        }
    }
}

