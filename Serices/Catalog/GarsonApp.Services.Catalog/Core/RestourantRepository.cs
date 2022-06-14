using GarsonApp.Services.Catalog.Abstract.Repositories;
using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Core
{
    public class RestourantRepository : IRestourantRepository
    {
        List<Restaurant> restaurants = new List<Restaurant> {
            new Restaurant() { Id = 1, RestourantName = "Uğur Restoran", 
                                RestourantDescription = "Uğur Restoran Açıklama", 
                                minOrderPrice = 50, 
                                OrderHome = true, 
                                OrderTable = true,
                                TypeId = 1},

            new Restaurant() { Id = 2, RestourantName = "Berkant Restoran" , 
                                RestourantDescription = "Berkant Restoran Açıklama", 
                                minOrderPrice = 70, 
                                OrderHome = false, 
                                OrderTable = true,
                                TypeId = 1},
            
            new Restaurant() { Id = 3, RestourantName = "Osman Gültekin Restoran" ,
                                RestourantDescription = "Osman Gültekin Restoran Açıklama", 
                                minOrderPrice = 20, 
                                OrderHome = true, 
                                OrderTable = false,
                                TypeId = 2}
        };

        public RestourantRepository()
        {
        }

        public int Count(Expression<Func<Restaurant, bool>> filter = null)
        {
            return restaurants.Count;
        }

        public bool Delete(int id)
        {
            var res = restaurants.Where(x => x.Id == id).ToList();
            if (res.Count > 0)
            {
                int index = restaurants.IndexOf(res[0]);
                if (index == -1) return false;
                restaurants.RemoveAt(index);
                return true;
            }

            return false;
        }

        public List<Restaurant> GetAll(int take, Expression<Func<Restaurant, bool>> filter = null)
        {
            if (filter != null)
                return restaurants.Where(filter.Compile()).Take(take).ToList();
            else return restaurants;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Insert(Restaurant entity)
        {
            restaurants.Add(entity);
            return true;
        }

        public bool Update(Restaurant entity)
        {
            var res = restaurants.Where(x => x.Id == entity.Id).ToList();
            if (res.Count > 0)
            {
                int index = restaurants.IndexOf(res[0]);
                if (index == -1) return false;

                restaurants[index] = entity;
                return true;
            }

            return false;
        }
    }
}
