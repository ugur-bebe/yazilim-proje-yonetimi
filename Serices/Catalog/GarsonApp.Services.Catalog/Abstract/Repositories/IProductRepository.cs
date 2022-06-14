using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract
{
    public interface IProductRepository
    {
        bool Insert(Product entity);
        bool Update(Product entity);
        bool Delete(int id);

        Product GetById(int id);

        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);

        int Count(Expression<Func<Product, bool>> filter = null);
    }
}
