using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using BL.Services.CRUD;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;

namespace BL.Services.CartItem
{
	public class CartItemService : ICartItemService
	{
        private readonly IMapper _mapper;
        private readonly BookReservationDbContext _context;

        public CartItemService(BookReservationDbContext context, IMapper mapper)
		{
            _mapper = mapper;
            _context = context;
        }

        public void AddItem(CartItemDto itemDto)
        {
            using (IUoWCartItem uow = new EFUoWCartItem(_context))
            {
                var cartItemRepo = new CRUDService<DAL.Models.CartItem>(uow.CartItemRepository, _mapper);
                cartItemRepo.Create<CartItemDto>(itemDto);
                uow.Commit();
            }
        }

        public void RemoveItem(object id)
        {
            using (IUoWCartItem uow = new EFUoWCartItem(_context))
            {
                var cartItemRepo = new CRUDService<DAL.Models.CartItem>(uow.CartItemRepository, _mapper);
                cartItemRepo.DeleteById(id);
                uow.Commit();
            }
        }
    }
}

