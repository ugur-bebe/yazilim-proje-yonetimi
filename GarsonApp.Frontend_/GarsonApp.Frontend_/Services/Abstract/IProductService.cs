using GarsonApp.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAll(int restourantId);

        Task<int> Count(Expression<Func<Product, bool>> filter = null);

        Task<Product> GetById(int id);

        Task Add(Product product);

        Task Delete(int id);

        Task Update(Product product);
    }
}
