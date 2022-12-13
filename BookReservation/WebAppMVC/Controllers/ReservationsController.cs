using AutoMapper;
using BL.DTOs;
using BL.Facades.OrderFac;
using BL.Services.ReservationServ;
using BL.Services.UserServ;
using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using System.Security.Claims;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Route("/reservations/{userId:int}"), Authorize]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IOrderFacade _orderFacade;

        public ReservationsController(IReservationService reservationService,
            IOrderFacade orderFacade)
        {
            _reservationService = reservationService;
            _orderFacade = orderFacade;
        }

        private ReservationModel<ReservationDetailDto>? Reservations(int page, RentState state, int userId)
        {
            if (page < 1) page = 1;
            string group = GetGroup(User);
            if (!int.TryParse(User.Identity?.Name, out int signedUserId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return null;
            }
            if (userId != signedUserId && group == "User")
            {
                userId = signedUserId;
            }
            var result = _reservationService.ShowReservations(userId, page, state);
            ReservationModel<ReservationDetailDto> model = new()
            {
                CurrentState = state,
                Items = result.Items,
                NextPageEmpty = result.NextPageEmpty,
                PageNumber = result.PageNumber ?? 1,
                Group = group,
                UserId = userId,
            };
            return model;
        }

        private static string GetGroup(ClaimsPrincipal user)
        {
            string result;
            var identity = (ClaimsIdentity?)user.Identity;
            if (identity == null)
            {
                result = "User";
            }
            else
            {
                result = identity.Claims
               .Where(c => c.Type == ClaimTypes.Role)
               .Select(c => c.Value)
               .FirstOrDefault("User");
            }
            return result;
        }

        [Route("cancel/{id:int}/{page:int?}")]
        [Authorize]
        public async Task<IActionResult> Cancel(int userId, int id, int page = 1)
        {
            string group = GetGroup(User);
            if (!int.TryParse(User.Identity?.Name, out int signedUserId) ||
                (userId != signedUserId && group == "User"))
            {
                ModelState.AddModelError("UserId", "Invalid permissions!");
                return View("Reservations", Reservations(page, RentState.Reserved, userId));
            }
            var isChanged = await _orderFacade.ReturnBook(id, userId, RentState.Canceled);
            if (!isChanged)
            {
                ModelState.AddModelError("Id", "Invalid operation!");
            };
            return View("Reservations", Reservations(page, RentState.Reserved, userId));
        }

        [Route("renew/{id:int}/{page:int?}")]
        [Authorize]
        public async Task<IActionResult> Renew(int userId, int id, int page = 1)
        {
            string group = GetGroup(User);
            if (!int.TryParse(User.Identity?.Name, out int signedUserId) ||
                (userId != signedUserId && group == "User"))
            {
                ModelState.AddModelError("UserId", "Invalid permissions!");
                return View("Reservations", Reservations(page, RentState.Expired, userId));
            }
            if (!await _orderFacade.ReserveBook(id, userId))
            {
                ModelState.AddModelError("Id", "Invalid operation!");
            }
            return View("Reservations", Reservations(page, RentState.Expired, userId));
        }

        [HttpGet("reserved/{page:int?}")]
        public IActionResult Reserved(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Reserved, userId));
        }

        [HttpGet("canceled/{page:int?}")]
        public IActionResult Canceled(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Canceled, userId));
        }

        [HttpGet("active/{page:int?}")]
        public IActionResult Active(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Active, userId));
        }

        [HttpGet("returned/{page:int?}")]
        public IActionResult Returned(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Returned, userId));
        }

        [HttpGet("expired/{page:int?}")]
        public IActionResult Expired(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Expired, userId));
        }

        [HttpGet("{page:int?}")]
        public IActionResult Index(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Reserved, userId));
        }
    }
}
