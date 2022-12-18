using AutoMapper;
using BL.Services.CartItemServ;
using BL.Services.ReviewServ;
using BL.Services.StockServ;
using DAL.Enums;
using DAL.Models;
using Infrastructure.UnitOfWork;

namespace BL.Facades.UserFac
{
    public class UserFacade : IUserFacade
    {
        private readonly IStockService stockService;
        private readonly ICartItemService cartService;
        private readonly IReviewService reviewService;
        private readonly IUoWUser uow;

        public UserFacade(IStockService stockService,
            ICartItemService cartService,
            IReviewService reviewService,
            IUoWUser uow)
        {
            this.stockService = stockService;
            this.cartService = cartService;
            this.reviewService = reviewService;
            this.uow = uow;
        }

        public void DeleteReservation(Reservation reservation)
        {
            switch (reservation.State)
            {
                case RentState.Reserved:
                    stockService.BookReturnedStock(reservation.BookId);
                    return;
                case RentState.Active:
                    stockService.BookReturnedStock(reservation.BookId);
                    return;
            }
            uow.ReservationRepository.Delete(reservation.Id);
        }

        public async Task DeleteUser(int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            var reviews = user.Reviews;
            foreach (var review in reviews)
            {
                await reviewService.DeleteReview(review.Id, commit: false);
            }
            await cartService.EmptyCart(userId, false);
            var rents = user.Rents;
            foreach (var rent in rents)
            {
                DeleteReservation(rent);
            }
            await uow.CommitAsync();
        }
    }
}
