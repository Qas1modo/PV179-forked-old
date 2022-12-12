using AutoMapper;
using BL.DTOs;
using BL.Services.ReservationServ;
using BL.Services.UserServ;
using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize]
        private PaginationModel<ReservationDetailDto>? Reservations(int page, RentState state) 
        {
            if (page < 1)
            {
                page = 1;
            }
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return null;
            }
            var result = _reservationService.ShowReservations(userId, page, state);
            PaginationModel<ReservationDetailDto> model = new()
            {
                CurrentState = state,
                Items = result.Items,
                NextPageEmpty = result.NextPageEmpty,
                PageNumber = result.PageNumber ?? 1
            };
            return model;
        }


        [Authorize, HttpGet]
        public IActionResult Reserved(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Reserved));
        }

        [Authorize, HttpGet]
        public IActionResult Canceled(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Canceled));
        }

        [Authorize, HttpGet]
        public IActionResult Active(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Active));
        }

        [Authorize, HttpGet]
        public IActionResult Returned(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Returned));
        }

        [Authorize, HttpGet]
        public IActionResult Expired(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Expired));
        }

        [Authorize, HttpGet]
        public IActionResult Overdue(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Overdue));
        }

        [Authorize, HttpGet]
        public IActionResult Index(int id = 1)
        {
            return View("Reservations", Reservations(id, RentState.Reserved));
        }
    }
}
