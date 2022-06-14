using GarsonApp.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services.Abstract
{
    public interface IAccountService
    {
        Task<User> GetAll(User filter = null);

        Task<int> Count(Expression<Func<User, bool>> filter = null);

        Task<BasketModel> GetById(int id);

        Task Add(BasketModel category);

        Task Delete(int id);

        Task Update(BasketModel category);
    }
}
