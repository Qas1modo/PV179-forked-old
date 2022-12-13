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
using System.Transactions;

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
                bool isReserved = await stockService.ReserveBookStock(cartItem.BookId);
                if (!isReserved)
                {
                    return false;
                }
                rentService.CreateReservation(mapper.Map<ReservationDto>(cartItem));
            }
            await cartService.EmptyCart(userId);
            await uow.CommitAsync();
            return true;
        }

        public async Task<bool> ReserveBook(int reservationId, int userId)
        {
            int bookId = await rentService.ChangeState(reservationId, RentState.Reserved, userId);
            if (bookId == -1 || !await stockService.ReserveBookStock(bookId))
            {
                return false;
            }
            await uow.CommitAsync();
            return true;
        }

        public async Task<bool> ReturnBook(int reservationId, int userId, RentState newState = RentState.Returned)
        {
            Reservation reservation = await uow.ReservationRepository.GetByID(reservationId);
            if (userId == -1)
            {
                userId = reservation.UserId;
            }
            int bookId = await rentService.ChangeState(reservationId, newState, userId);
            if (bookId == -1 || ! await stockService.BookReturnedStock(bookId))
            {
                return false;
            }
            await uow.CommitAsync();
            return true;
        }
    }
}

