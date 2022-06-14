using GarsonApp.Basket.Abstract;
using GarsonApp.Basket.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.DAL
{
    public class BasketDal : IBasketDal
    {
        IBasketRepository _basketRepository;
        public BasketDal(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /* public int Count(Expression<Func<Category, List<Category>>> filter = null)
         {
             Func<Category, List<Category>> isTeenAger = filter.Compile();
             List<Category> result = isTeenAger(new Category { });

             return categories.Count;
         }*/

        public int Count(Expression<Func<BasketModel, bool>> filter = null)
        {
            return _basketRepository.Count(filter);
        }

        public bool Delete(int id)
        {
            if (_basketRepository.Delete(id))
            {
                return true;
            }

            return false;
        }

        public List<BasketModel> GetAll(Expression<Func<BasketModel, bool>> filter = null)
        {
            return _basketRepository.GetAll(filter);
        }

        public BasketModel GetById(int id)
        {
            return _basketRepository.GetById(id);
        }

        public bool Insert(BasketModel category)
        {
            if (_basketRepository.Insert(category))
                return true;
            else
                return false;
        }

        public bool Update(BasketModel category)
        {
            if (_basketRepository.Update(category))
                return true;
            else
                return false;
        }
    }
}
