using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAppMVC.Models;
using BL.Services.CartItemServ;
using BL.Facades.OrderFac;
using DAL.Models;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartItemService cartItemService;

        private readonly IOrderFacade orderFacade;

        public CartController(ICartItemService cartItemService,
            IOrderFacade orderFacade)
        {
            this.cartItemService = cartItemService;
            this.orderFacade = orderFacade;
        }

        public async Task<IActionResult> Index()
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
            }
            var model = new CartIndexModel()
            {
                cartItems = await cartItemService.GetCartItems(userId),
            };
            return View(model);
        }

        [Route("cart/DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return RedirectToAction(nameof(Index));
            }

            await cartItemService.RemoveItem(itemId, userId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EmptyCart()
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
            }
            await cartItemService.EmptyCart(userId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MakeOrder()
        {
            if (!int.TryParse(User.Identity?.Name, out int userId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
            }
            if (!await orderFacade.MakeOrder(userId))
            {
                ModelState.AddModelError("Id", "Cannot have more than 5 concurrent reservations!");
            }
            var model = new CartIndexModel()
            {
                cartItems = await cartItemService.GetCartItems(userId),
            };
            return View("Index", model);
        }
    }
}

