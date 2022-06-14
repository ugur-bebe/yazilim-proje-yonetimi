using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        IBasketService _basketService;
        public BasketController(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            string id = httpContextAccessor.HttpContext.Session.GetString("user_id");
            if (id == null)
            {
                foreach (var cookie in httpContextAccessor.HttpContext.Request.Cookies.Keys)
                {
                    httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
                }

                httpContextAccessor.HttpContext.Response.Redirect("Login");
            }

            _basketService = basketService;
        }

        [HttpPost]
        [Route("Basket/InsertToBasket")]
        public IActionResult InsertProduct([FromBody] BasketModel basket)
        {
            _basketService.Add(basket);
            return Ok();
        }

        [HttpGet]
        [Route("Basket")]
        public IActionResult GetAllBasket()
        {
            ViewBag.BasketList = _basketService.GetAll(1).Result;
            return View("Views/Catalog/Basket.cshtml");
        }

        [HttpGet]
        [Route("res")]
        public IActionResult res()
        {
            return View("Views/RESERVATION/RESERVATION.cshtml");
        }
        
        [HttpGet]
        [Route("pay")]
        public IActionResult pay()
        {
            return View("Views/RESERVATION/PAYMENT.cshtml");
        }

        [HttpGet]
        [Route("Basket/DeleteBasketItem")]
        public async Task<IActionResult> DeleteBasketItem(int itemId)
        {
            await _basketService.Delete(itemId);
            return Ok();
        }
    }
}
