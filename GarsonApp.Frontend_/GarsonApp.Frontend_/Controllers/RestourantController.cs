using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Controllers
{
    public class RestourantController : Controller
    {
        IRestourantService _restourantService;
        public RestourantController(IRestourantService categoryService, IHttpContextAccessor httpContextAccessor)
        {
            string id = httpContextAccessor.HttpContext.Session.GetString("user_id");
            if (id == null)
            {
                foreach (var cookie in httpContextAccessor.HttpContext.Request.Cookies.Keys)
                {
                    httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
                }

                httpContextAccessor.HttpContext.Response.Redirect("../Login");
            }

            _restourantService = categoryService;
        }

        [HttpGet]
        [Route("Restourant/Search")]
        public async Task<IActionResult> Index(int type, int minPrice = 10000, int take = 10, bool OrderHome = false, bool OrderTable = false)
        {

            ViewBag.MinPrice = (minPrice != 10000) ? minPrice : 0;

            ViewBag.ActiveAllOrderClass = "";
            ViewBag.ActiveOrderHomeClass = "";
            ViewBag.ActiveAllOrderClass = "";
            string minPriceUrlParameter = (minPrice != 10000) ? "minPrice=" + minPrice + "&" : "";
            string typeUrlParameter = (type != 0) ? "type=" + type + "&" : "";

            string url = "http://" + Request.Host.ToString() + "/Restourant/Search?" + minPriceUrlParameter + "" + typeUrlParameter;

            ViewBag.ActiveAllOrderUrl = url + "OrderHome=true&OrderTable=true";
            ViewBag.ActiveOrderHomeUrl = url + "OrderHome=true";
            ViewBag.ActiveOrderTableUrl = url + "OrderTable=true";

            if (OrderHome && OrderTable)
            {
                ViewBag.ActiveAllOrderClass = "current";
            }
            else if (OrderHome)
            {
                ViewBag.ActiveOrderHomeClass = "current";
            }
            else if (OrderTable)
            {
                ViewBag.ActiveOrderTableClass = "current";
            }

            //Eğer başlangıçta hiçbiri seçilmemişse tamamı gelmesi için her iki parametreyide true yapıyorum
            //(OrderHome ve OrderTable default olarak false)
            if (!OrderTable && !OrderHome)
            {
                OrderHome = true;
                OrderTable = true;
                ViewBag.ActiveAllOrderClass = "current";
            }

            var a = await _restourantService.GetAll(take, new Restourant { MinOrderPrice = minPrice, OrderHome = OrderHome, OrderTable = OrderTable, TypeId = type });
            ViewBag.RestourantList = a;
            return View("Views/Catalog/Search.cshtml");
        }
    }
}
