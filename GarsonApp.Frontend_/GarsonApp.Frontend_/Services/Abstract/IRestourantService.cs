using GarsonApp.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services.Abstract
{
    public interface IRestourantService
    {
        Task<List<Restourant>> GetAll(int take, Restourant filter = null);

        Task<int> Count(Expression<Func<Restourant, bool>> filter = null);

        Task<Restourant> GetById(int id);

        Task Add(Restourant category);

        Task Delete(int id);

        Task Update(Restourant category);
    }
}
