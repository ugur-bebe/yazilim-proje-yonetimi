using GarsonApp.Account.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Account.Abstract
{
    public interface IAccountRepository
    {
        bool Insert(User entity);

        bool Update(User entity);

        bool Delete(int id);

        User GetById(int id);

        List<User> GetAll(Expression<Func<User, bool>> filter = null);

        int Count(Expression<Func<User, bool>> filter = null);
    }
}
