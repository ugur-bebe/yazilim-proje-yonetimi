using GarsonApp.Basket.Abstract;
using GarsonApp.Basket.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Core
{
    public class BasketRepository : IBasketRepository
    {
        List<BasketModel> categories = new List<BasketModel> {
            new BasketModel
            {
                id = 1,
                piece = 10,
                productId = 1,
                ownerId = 1
            },
            new BasketModel
            {
                id = 2,
                piece = 5,
                productId = 1,
                ownerId = 1
            },
            new BasketModel
            {
                id = 3,
                piece = 1,
                productId = 3,
                ownerId = 2
            },
            new BasketModel
            {
                id = 4,
                piece = 2,
                productId = 2,
                ownerId = 2
            },
            new BasketModel
            {
                id = 5,
                piece = 2,
                productId = 2,
                ownerId = 3
            },
            new BasketModel
            {
                id = 6,
                piece = 1,
                productId = 4,
                ownerId = 3
            }
        };

        public BasketRepository()
        {
        }

        public int Count(Expression<Func<BasketModel, bool>> filter = null)
        {
            return categories.Count;
        }

        public bool Delete(int id)
        {
            var res = categories.Where(x => x.id == id).ToList();
            if (res.Count > 0)
            {
                int index = categories.IndexOf(res[0]);
                if (index == -1) return false;
                categories.RemoveAt(index);
                return true;
            }

            return false;
        }

        public List<BasketModel> GetAll(Expression<Func<BasketModel, bool>> filter = null)
        {
            if (filter != null)
                return categories.Where(filter.Compile()).ToList();

            return categories;
        }

        public BasketModel GetById(int id)
        {
            return categories.Where(x => x.id == id).FirstOrDefault();
        }

        public bool Insert(BasketModel entity)
        {
            categories.Add(entity);
            return true;
        }

        public bool Update(BasketModel entity)
        {
            var res = categories.Where(x => x.id == entity.id).ToList();
            if (res.Count > 0)
            {
                int index = categories.IndexOf(res[0]);
                if (index == -1) return false;

                categories[index] = entity;
                return true;
            }

            return false;
        }
    }
}
