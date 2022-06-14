using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.DAL
{
    public class SubCategoryDal : ISubCategoryDal
    {
        ISubCategoryRepository _entityRepository;
        public SubCategoryDal(ISubCategoryRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        /* public int Count(Expression<Func<Category, List<Category>>> filter = null)
         {
             Func<Category, List<Category>> isTeenAger = filter.Compile();
             List<Category> result = isTeenAger(new Category { });

             return categories.Count;
         }*/

        public int Count(Expression<Func<SubCategory, bool>> filter = null)
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

        public List<SubCategory> GetAll(Expression<Func<SubCategory, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public SubCategory GetById(int id)
        {
            return _entityRepository.GetById(id);
        }

        public bool Insert(SubCategory category)
        {
            if (_entityRepository.Insert(category))
                return true;
            else
                return false;
        }

        public bool Update(SubCategory category)
        {
            if (_entityRepository.Update(category))
                return true;
            else
                return false;
        }
    }
}
