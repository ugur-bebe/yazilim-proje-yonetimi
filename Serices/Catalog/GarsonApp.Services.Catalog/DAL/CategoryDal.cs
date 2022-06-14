using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.DAL
{
    public class CategoryDal : ICategoryDal
    {
        ICategoryRepository _entityRepository;
        public CategoryDal(ICategoryRepository entityRepository)
        {
            this._entityRepository = entityRepository;
        }

        /* public int Count(Expression<Func<Category, List<Category>>> filter = null)
         {
             Func<Category, List<Category>> isTeenAger = filter.Compile();
             List<Category> result = isTeenAger(new Category { });

             return categories.Count;
         }*/

        public int Count(Expression<Func<Category, bool>> filter = null)
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

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public Category GetById(int id)
        {
            return _entityRepository.GetById(id);
        }

        public bool Insert(Category category)
        {
            if (_entityRepository.Insert(category))
                return true;
            else
                return false;
        }

        public bool Update(Category category)
        {
            if (_entityRepository.Update(category))
                return true;
            else
                return false;
        }
    }
}
