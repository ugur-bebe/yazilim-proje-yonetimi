using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract
{
    public interface IProductDal
    {
        bool Insert(Product category);

        bool Update(Product category);

        bool Delete(int id);

        Product GetById(int id);

        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);

        int Count(Expression<Func<Product, bool>> filter = null);
    }
}
