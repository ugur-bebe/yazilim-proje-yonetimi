using GarsonApp.Services.Catalog.Abstract.Dal;
using GarsonApp.Services.Catalog.Abstract.Repositories;
using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.DAL
{
    public class RestourantDal : IRestourantDal
    {
        IRestourantRepository _entityRepository;
        public RestourantDal(IRestourantRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        /* public int Count(Expression<Func<Category, List<Category>>> filter = null)
         {
             Func<Category, List<Category>> isTeenAger = filter.Compile();
             List<Category> result = isTeenAger(new Category { });

             return categories.Count;
         }*/

        public int Count(Expression<Func<Restaurant, bool>> filter = null)
        {
            return _entityRepository.Count(filter);
        }

        public bool Delete(int id)
        {
            if (_entityRepository.Delete(id))
            {
                return true;
            }

            return false;
        }

        public List<Restaurant> GetAll(int take, Expression<Func<Restaurant, bool>> filter = null)
        {
            return _entityRepository.GetAll(take, filter);
        }

        public Restaurant GetById(int id)
        {
            return _entityRepository.GetById(id);
        }

        public bool Insert(Restaurant category)
        {
            if (_entityRepository.Insert(category))
                return true;
            else
                return false;
        }

        public bool Update(Restaurant category)
        {
            if (_entityRepository.Update(category))
                return true;
            else
                return false;
        }
    }
}
