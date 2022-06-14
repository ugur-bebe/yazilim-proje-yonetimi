using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract
{
    public interface ICategoryRepository
    {
        bool Insert(Category entity);
        bool Update(Category entity);
        bool Delete(int id);

        Category GetById(int id);

        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);

        int Count(Expression<Func<Category, bool>> filter = null);
    }
}
