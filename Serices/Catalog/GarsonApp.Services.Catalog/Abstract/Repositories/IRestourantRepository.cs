using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Abstract.Repositories
{
    public interface IRestourantRepository
    {
        bool Insert(Restaurant entity);
        bool Update(Restaurant entity);
        bool Delete(int id);
        Restaurant GetById(int id);
        List<Restaurant> GetAll(int take, Expression<Func<Restaurant, bool>> filter = null);
        int Count(Expression<Func<Restaurant, bool>> filter = null);
    }
}
