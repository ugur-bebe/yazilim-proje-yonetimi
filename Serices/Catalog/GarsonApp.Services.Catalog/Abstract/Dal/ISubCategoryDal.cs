using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract
{
    public interface ISubCategoryDal
    {
        bool Insert(SubCategory category);

        bool Update(SubCategory category);

        bool Delete(int id);

        SubCategory GetById(int id);

        List<SubCategory> GetAll(Expression<Func<SubCategory, bool>> filter = null);

        int Count(Expression<Func<SubCategory, bool>> filter = null);
    }
}
