using GarsonApp.Services.Catalog.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarsonApp.Business.Concrete;

namespace GarsonApp.Services.Catalog.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("Category/GetAllCategory")]
        public List<Category> GetCategory()
        {
            return _categoryService.GetAll().Data;
        }

        [HttpPost]
        [Route("Category/InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPost]
        [Route("Category/UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpPost]
        [Route("Category/DeleteCategory")]
        public IActionResult DeleteProductFromId(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
