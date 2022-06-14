using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Controllers
{
    public class CatalogController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View("view/Catalog/index.cshtml");
        }
    }
}
