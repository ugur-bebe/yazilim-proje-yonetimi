using GarsonApp.Basket.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Abstract
{
    public interface IBasketService
    {
        Response<List<BasketModel>> GetAll(Expression<Func<BasketModel, bool>> filter = null);

        Response<int> Count(Expression<Func<BasketModel, bool>> filter = null);

        Response<BasketModel> GetById(int id);

        Response<NoContext> Add(BasketModel basketModel);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(BasketModel basketModel);
    }
}
