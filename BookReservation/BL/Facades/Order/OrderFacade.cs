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

namespace BL.Facades.OrderFac
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

        public async Task<bool> MakeOrder(int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            foreach (var cartItem in user.CartItems)
            {
                var isReserved = await stockService.ReserveBookStock(cartItem.BookId);
                if (!isReserved)
                {
                    return false;
                }
                ReservationDto newReservation = mapper.Map<ReservationDto>(cartItem);
                newReservation.State = RentState.Reserved;
                newReservation.ReservedAt = new DateTime();

                await rentService.CreateReservation(newReservation);
            }
            await cartService.EmptyCart(userId);
            return true;
        }

        public async Task<bool> ReturnBook(int reservationId, RentState newState = RentState.Returned)
        {
            Reservation reservation = await uow.ReservationRepository.GetByID(reservationId);
            var isReturned = await stockService.BookReturnedStock(reservation.BookId);
            if (!isReturned)
            {
                return false;
            }
            return await rentService.ChangeState(reservationId, newState, reservation.UserId);
        }
    }
}

