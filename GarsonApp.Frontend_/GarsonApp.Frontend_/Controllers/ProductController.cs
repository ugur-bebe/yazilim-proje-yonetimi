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
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor)
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
            _productService = productService;
        }

        [HttpGet]
        [Route("Product/GetAllProduct")]
        public async Task<IActionResult> GetProducts(int restourantId)
        {
            var a = await _productService.GetAll(restourantId);
            ViewBag.RestourantProductList = a;

            return View("Views/Catalog/RestourantDetail.cshtml");
        }

        [HttpPost]
        [Route("Product/InsertProduct")]
        public IActionResult InsertProduct(Product product)
        {
            _productService.Add(product);
            return Ok();
        }

        [HttpPost]
        [Route("Product/UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpPost]
        [Route("Product/DeleteProduct")]
        public IActionResult DeleteProductFromId(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
