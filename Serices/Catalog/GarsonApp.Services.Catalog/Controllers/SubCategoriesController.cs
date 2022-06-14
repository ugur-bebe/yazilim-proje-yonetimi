using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTYS_PROJE.Business.Concrete;

namespace GarsonApp.Services.Catalog.Controllers
{
    public class SubCategoriesController : Controller
    {
        ISubCategoryService _categoryService;
        public SubCategoriesController(ISubCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("SubCategory/GetAllSubCategory")]
        public List<SubCategory> GetSubCategory()
        {
            return _categoryService.GetAll().Data;
        }

        [HttpPost]
        [Route("SubCategory/InsertSubCategory")]
        public IActionResult InsertSubCategory(SubCategory category)
        {
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPost]
        [Route("SubCategory/UpdateSubCategory")]
        public IActionResult UpdateSubCategory(SubCategory category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpPost]
        [Route("SubCategory/DeleteSubCategory")]
        public IActionResult DeleteSubCategoryFromId(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
