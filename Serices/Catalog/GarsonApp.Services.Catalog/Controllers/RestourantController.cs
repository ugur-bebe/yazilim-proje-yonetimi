using GarsonApp.Services.Catalog.Abstract.Services;
using GarsonApp.Services.Catalog.Concrete.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Controllers
{
    public class RestourantController : Controller
    {
        IRestourantService _restourantService;
        public RestourantController(IRestourantService restourantService)
        {
            _restourantService = restourantService;
        }

        [HttpGet]
        [Route("Restourant/GetAllRestourant")]
        public List<Restaurant> GetProducts(int take, Restaurant filter)
        {
            if (filter.Id != 0)
                return _restourantService.GetAll(take, x => x.Id == filter.Id
                                                        && ((x.OrderHome == filter.OrderHome) || (x.OrderTable == filter.OrderTable)) 
                                                        && x.minOrderPrice <= filter.minOrderPrice
                                                        && (x.TypeId == filter.TypeId || filter.TypeId == 0)).Data;

            if (filter.OrderHome && filter.OrderTable)
                return _restourantService.GetAll(take, x => ((x.OrderHome == true) || (x.OrderTable == true)) 
                                                        && x.minOrderPrice <= filter.minOrderPrice
                                                        && (x.TypeId == filter.TypeId || filter.TypeId == 0)).Data;

            if (filter.OrderHome)
                return _restourantService.GetAll(take, x => (x.OrderHome == true) 
                                                       && x.minOrderPrice <= filter.minOrderPrice
                                                       && (x.TypeId == filter.TypeId || filter.TypeId == 0)).Data;

            if (filter.OrderTable)
                return _restourantService.GetAll(take, x => (x.OrderTable == true) 
                                                       && x.minOrderPrice <= filter.minOrderPrice
                                                       && (x.TypeId == filter.TypeId || filter.TypeId == 0)).Data;


            return _restourantService.GetAll(take).Data;
        }

        [HttpPost]
        [Route("Restourant/InsertRestourant")]
        public IActionResult InsertProduct(Restaurant product)
        {
            _restourantService.Add(product);
            return Ok();
        }

        [HttpPost]
        [Route("Restourant/UpdateRestourant")]
        public IActionResult UpdateProduct(Restaurant product)
        {
            _restourantService.Update(product);
            return Ok();
        }

        [HttpPost]
        [Route("Restourant/DeleteRestourant")]
        public IActionResult DeleteProductFromId(int id)
        {
            _restourantService.Delete(id);
            return Ok();
        }
    }
}
