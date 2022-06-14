using GarsonApp.Services.Catalog.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTYS_PROJE.Business.Concrete;

namespace GarsonApp.Services.Catalog.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("Product/GetAllProduct")]
        public List<Product> GetProducts(int restourantId)
        {
            return _productService.GetAll(x=> x.restourantId == restourantId).Data;
        }

        [HttpGet]
        [Route("Product/GetProductById")]
        public Product GetProductById(int id)
        {
            return _productService.GetAll(x => x.id == id).Data.FirstOrDefault();
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
