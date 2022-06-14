using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_PROJE.Business.Concrete
{
    public interface ISubCategoryService
    {
        Response<List<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null);

        Response<int> Count(Expression<Func<SubCategory, bool>> filter = null);

        Response<SubCategory> GetById(int id);

        Response<NoContext> Add(SubCategory category);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(SubCategory category);
    }
}
