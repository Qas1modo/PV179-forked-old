using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAppMVC.Models;
using BL.Services.CartItemServ;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartItemService cartItemService;

        public CartController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
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

        public async Task<IActionResult> MakeOrder()
        {
            // todo for now, do nothing

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
    }
}

