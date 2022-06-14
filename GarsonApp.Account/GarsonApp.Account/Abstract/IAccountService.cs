
using GarsonApp.Account.Concrete;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Account.Abstract
{
    public interface IAccountService
    {
        Response<List<User>> GetAll(Expression<Func<User, bool>> filter = null);

        Response<int> Count(Expression<Func<User, bool>> filter = null);

        Response<User> GetById(int id);

        Response<NoContext> Add(User user);

        Response<NoContext> Delete(int id);

        Response<NoContext> Update(User user);
    }
}
