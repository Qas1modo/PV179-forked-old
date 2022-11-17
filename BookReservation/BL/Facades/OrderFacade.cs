using AutoMapper;
using BL.DTOs.BasicDtos;
using BL.Services.CartItem;
using BL.Services.Reservation;
using BL.Services.Stock;
using BL.Services.UserService;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
namespace BL.Facades
{
	public class OrderFacade
	{
        private IStockService stockService;
        private ICartItemService cartService;
		private IRentService rentService;
		private IUserService userService;
		private BookReservationDbContext context;
		private IMapper mapper;

		public OrderFacade(BookReservationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

        public bool MakeOrder(int userId)
		{
			//cartService = new CartItemService(context, mapper);
			//stockService = new StockService(context, mapper);
			//rentService = new RentService(context, mapper);
			//userService = new UserService(context, mapper);
			//UserDto user = userService.GetUser(userId);
			//foreach (var cartItem in user.CartItems)
			//{
			//	if (stockService.ReserveBookStock(cartItem.BookId))
			//	{
			//		return false;
			//	}
			//	rentService.CreateReservation(cartItem.BookId, user.Id, cartItem.LoanPeriod, cartItem.TotalPrice);
			//}
			//cartService.EmptyCart(userId);

			return true;
		}
	}
}

