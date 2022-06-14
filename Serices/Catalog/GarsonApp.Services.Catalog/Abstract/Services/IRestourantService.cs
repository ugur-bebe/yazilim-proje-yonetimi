using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract.Services
{
    public interface IRestourantService
    {
        Response<List<Restaurant>> GetAll(int take, Expression<Func<Restaurant, bool>> filter = null);

        Response<int> Count(Expression<Func<Restaurant, bool>> filter = null);

        Response<Restaurant> GetById(int id);

        Response<NoContext> Add(Restaurant category);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(Restaurant category);
    }
}
