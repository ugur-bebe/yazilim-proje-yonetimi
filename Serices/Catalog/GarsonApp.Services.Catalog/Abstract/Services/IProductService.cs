using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_PROJE.Business.Concrete
{
    public interface IProductService
    {
        Response<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);

        Response<int> Count(Expression<Func<Product, bool>> filter = null);

        Response<Product> GetById(int id);

        Response<NoContext> Add(Product category);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(Product category);
    }
}
