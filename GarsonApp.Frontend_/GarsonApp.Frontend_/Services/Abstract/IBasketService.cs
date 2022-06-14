using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services.Abstract
{
    public interface IBasketService
    {
        Task<List<BasketDto>> GetAll(int userId);

        Task<int> Count(Expression<Func<BasketModel, bool>> filter = null);

        Task<BasketModel> GetById(int id);

        Task Add(BasketModel category);

        Task Delete(int id);

        Task Update(BasketModel category);
    }
}
