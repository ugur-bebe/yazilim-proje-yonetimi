using GarsonApp.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Infrastructure
{
    public class API
    {
        public static class CatalogApi
        {
            private static string baseUri = "http://localhost:5011";
            public static string GetAllCatalogItems(int page, int take, int? brand, int? type)
            {
                var filterQs = "";

                if (type.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : string.Empty;
                    filterQs = $"/type/{type.Value}/brand/{brandQs}";
                }
                else if (brand.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : string.Empty;
                    filterQs = $"/type/all/brand/{brandQs}";
                }
                else
                {
                    filterQs = string.Empty;
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllBrands()
            {
                return $"{baseUri}catalogBrands";
            }
        }

        public static class CategoryApi
        {
            private static string baseUri = "http://localhost:5011";
            public static string GetAllCategoryes()
            {
                return $"{baseUri}/Category/GetAllCategory";
            }
        }

        public static class RestourantApi
        {
            private static string baseUri = "http://localhost:5011";
            public static string GetAllRestourant(int take, Restourant filter = null)
            {
                return $"{baseUri}/Restourant/GetAllRestourant?take={take}&&" + createUrlFilterFromEntity<Restourant>(filter);
            }
        }

        public static class ProductApi
        {
            private static string baseUri = "http://localhost:5011";
            public static string GetAllProducts(int restourantId)
            {
                return $"{baseUri}/Product/GetAllProduct?restourantId=" + restourantId;
            }
            public static string GetProductById(int productId)
            {
                return $"{baseUri}/Product/GetProductById?id=" + productId;
            }
        }

        public static class BasketApi
        {
            private static string baseUri = "http://localhost:5013";
            public static string GetAllBasket(int ownerId)
            {
                return $"{baseUri}/Basket/GetAllBasket?ownerId=" + ownerId;
            }

            public static string InsertBasket()
            {
                return $"{baseUri}/Basket/InsertToBasket";
            }

            internal static string DeleteBasketItem(int id)
            {
                return $"{baseUri}/Basket/DeleteBasketItem?id=" + id;
            }
        }

        public static class AccountApi
        {
            private static string baseUri = "http://localhost:5015";
            public static string GetAccountByUserNameAnadPassword(string userName, string password)
            {
                return $"{baseUri}/Account/GetUserByUserNameAndPassword?email=" + userName + "&password=" + password;
            }
        }

        public static string createUrlFilterFromEntity<T>(T entity)
        {
            string urlParameter = "";
            var parameterList = entity.GetType().GetProperties();
            foreach (var prop in parameterList)
            {
                object o = prop.GetValue(entity, null);
                if (o == null) continue;
                object val = o.ToString();
                string name = prop.Name;

                urlParameter += name + "=" + val;
                if (prop != parameterList.Last()) urlParameter += "&";
            }
            return urlParameter;
        }
    }
}
