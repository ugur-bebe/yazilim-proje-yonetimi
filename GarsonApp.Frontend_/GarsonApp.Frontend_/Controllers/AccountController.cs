using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("Login")]
        public IActionResult LoginPage()
        {
            return View("Views/Login/Login.cshtml");
        }

        [HttpGet]
        [Route("login_check")]
        public async Task<IActionResult> login_check(string email, string password)
        {
            User user = _accountService.GetAll(new User { email = email, password = password }).Result;

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email +""+password+""+user.id)
                };

                var identity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(claimsPrincipal);
                
                HttpContext.Session.SetString("user_id", user.id.ToString());

                return StatusCode(200);
            }

            return StatusCode(204);
        }

        [HttpGet]
        [Route("exit")]
        public IActionResult time_out()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Remove("user_id");

            return View("Views/Login/Login.cshtml");
        }
    }
}
