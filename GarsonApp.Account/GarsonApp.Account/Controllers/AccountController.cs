using GarsonApp.Account.Abstract;
using GarsonApp.Account.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Account.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _basketService;
        public AccountController(IAccountService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("Account/GetUserByUserNameAndPassword")]
        public User GetUsers(string email, string password)
        {
            return _basketService.GetAll(x => x.email == email && x.password == password).Data.FirstOrDefault();
        }

        [HttpPost]
        [Route("Account/CreateAccount")]
        public IActionResult CreateAccount([FromBody] User basket)
        {
            _basketService.Add(basket);
            return Ok();
        }

        [HttpPost]
        [Route("Account/UpdateAccount")]
        public IActionResult UpdateAccount(User basket)
        {
            _basketService.Update(basket);
            return Ok();
        }

        [HttpGet]
        [Route("Account/DeleteAccount")]
        public IActionResult DeleteAccount(int id)
        {
            _basketService.Delete(id);
            return Ok();
        }
    }
}
