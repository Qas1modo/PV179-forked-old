using AutoMapper;
using BL.DTOs;
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

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        private PaginationModel<ReservationDetailDto>? Reservations(int page, RentState state, int userId)
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
            PaginationModel<ReservationDetailDto> model = new()
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

        [HttpPut("cancel/{id:int}")]
        public async Task<IActionResult> Cancel(int userId, int id)
        {
            string group = GetGroup(User);
            if (!int.TryParse(User.Identity?.Name, out int signedUserId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return View();
            }
            if (userId != signedUserId && group == "User")
            {
                userId = signedUserId;
            }
            var isChanged = await _reservationService.ChangeState(id, RentState.Canceled, userId);
            if (!isChanged)
            {
                ModelState.AddModelError("Id", "Invalid permissions!");
            };
            return View("Reservations");
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

        [HttpGet("overdue/{page:int?}")]
        public IActionResult Overdue(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Overdue, userId));
        }

        [HttpGet("{page:int?}")]
        public IActionResult Index(int userId, int page = 1)
        {
            return View("Reservations", Reservations(page, RentState.Reserved, userId));
        }
    }
}
