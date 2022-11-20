using AutoMapper;
using BL.DTOs.BasicDtos;
using BL.Services.CartItemServ;
using BL.Services.ReservationServ;
using BL.Services.StockServ;
using BL.Services.UserServ;
using DAL;
using DAL.Enums;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Diagnostics;

namespace BL.Facades
{
	public class OrderFacade : IOrderFacade
	{
        private readonly IStockService stockService;
        private readonly ICartItemService cartService;
		private readonly IReservationService rentService;
		private readonly IUoWReservation uow;
		private readonly IMapper mapper;

		public OrderFacade(IStockService stockService,
			ICartItemService cartService,
			IReservationService rentService,
            IUoWReservation uow,
			IMapper mapper)
		{
			this.stockService = stockService;
			this.rentService = rentService;
			this.cartService = cartService;
			this.uow = uow;
			this.mapper = mapper;
		}

        public bool MakeOrder(int userId)
		{
			User user = uow.UserRepository.GetByID(userId);
			foreach (var cartItem in user.CartItems)
			{
				if (stockService.ReserveBookStock(cartItem.BookId))
				{
					return false;
				}
				rentService.CreateReservation(mapper.Map<ReservationDto>(cartItem));
			}
			cartService.EmptyCart(userId);
			return true;
		}

		public bool ReturnBook(int reservationId, bool cancel)
		{
			Reservation reservation = uow.ReservationRepository.GetByID(reservationId);
			if (!stockService.BookReturnedStock(reservation.BookId))
			{
				return false;
			}
			RentState newState = cancel ? RentState.Canceled : RentState.Returned;
			rentService.ChangeState(reservationId, newState);
			return true;
		}
    }
}

