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
    public class CatalogController : Controller
    {
        ICategoryService _categoryService;
        public CatalogController(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor)
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

            _categoryService = categoryService;
        }

        [Route("index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryList = await _categoryService.GetAll();
            return View("Views/Catalog/Index.cshtml");
        }
    }
}
