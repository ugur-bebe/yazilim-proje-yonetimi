using GarsonApp.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null);

        Task<int> Count(Expression<Func<Category, bool>> filter = null);

        Task<Category> GetById(int id);

        Task Add(Category category);

        Task Delete(int id);

        Task Update(Category category);

    }
}
