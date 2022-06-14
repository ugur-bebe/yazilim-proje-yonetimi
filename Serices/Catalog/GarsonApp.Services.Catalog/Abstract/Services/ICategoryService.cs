using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GarsonApp.Business.Concrete
{
    public interface ICategoryService
    {
        Response<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null);

        Response<int> Count(Expression<Func<Category, bool>> filter = null);

        Response<Category> GetById(int id);

        Response<NoContext> Add(Category category);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(Category category);
    }
}
