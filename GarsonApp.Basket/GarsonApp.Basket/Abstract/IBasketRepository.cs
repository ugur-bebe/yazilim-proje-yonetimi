using GarsonApp.Basket.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Abstract
{
    public interface IBasketRepository
    {
        bool Insert(BasketModel entity);
        bool Update(BasketModel entity);
        bool Delete(int id);

        BasketModel GetById(int id);

        List<BasketModel> GetAll(Expression<Func<BasketModel, bool>> filter = null);

        int Count(Expression<Func<BasketModel, bool>> filter = null);
    }
}
