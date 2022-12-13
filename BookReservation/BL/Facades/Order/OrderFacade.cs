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
using System.Linq;
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

        public async Task<bool> ReturnBook(int reservationId, int userId,
            RentState newState = RentState.Returned, bool commit = true)
        {
            int bookId = await rentService.ChangeState(reservationId, newState, userId);
            if (bookId == -1 || ! await stockService.BookReturnedStock(bookId))
            {
                return false;
            }
            if (commit) await uow.CommitAsync();
            return true;
        }

        public async Task ExpireOldReservations()
        {
            IEnumerable<Reservation> reservations = uow.ReservationRepository
                .GetQueryable()
                .Where(x => x.State == RentState.Reserved)
                .ToList();
            foreach (Reservation reservation in reservations)
            {
                if (reservation.State == RentState.Reserved &&
                    DateTime.Now.Subtract(reservation.ReservedAt).Days > 7)
                {
                    await ReturnBook(reservation.Id, reservation.UserId, RentState.Expired, false);
                }
            }
            await uow.CommitAsync();
        }
    }
}

