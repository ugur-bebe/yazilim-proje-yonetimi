using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarsonApp.Basket.Concrete.Models;
using GarsonApp.Basket.Abstract;

namespace GarsonApp.Basket.Controllers
{
    public class BasketController : Controller
    {
        IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("Basket/GetAllBasket")]
        public List<BasketModel> GetAllBasket(int ownerId)
        {
            return _basketService.GetAll(x=> x.ownerId == ownerId).Data;
        }

        [HttpPost]
        [Route("Basket/InsertToBasket")]
        public IActionResult InsertProduct([FromBody] BasketModel basket)
        {
            _basketService.Add(basket);
            return Ok();
        }

        [HttpPost]
        [Route("Basket/UpdateBasket")]
        public IActionResult UpdateBasket(BasketModel basket)
        {
            _basketService.Update(basket);
            return Ok();
        }

        [HttpGet]
        [Route("Basket/DeleteBasketItem")]
        public IActionResult DeleteBasketItem(int id)
        {
            _basketService.Delete(id);
            return Ok();
        }
    }
}
