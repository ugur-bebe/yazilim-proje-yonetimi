using GarsonApp.Basket.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Abstract
{
    public interface IBasketDal
    {
        bool Insert(BasketModel category);

        bool Update(BasketModel category);

        bool Delete(int id);

        BasketModel GetById(int id);

        List<BasketModel> GetAll(Expression<Func<BasketModel, bool>> filter = null);

        int Count(Expression<Func<BasketModel, bool>> filter = null);
    }
}
