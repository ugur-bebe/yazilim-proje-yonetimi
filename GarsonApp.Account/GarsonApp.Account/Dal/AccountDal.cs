using GarsonApp.Account.Abstract;
using GarsonApp.Account.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.DAL
{
    public class AccountDal : IAccountDal
    {
        IAccountRepository _accountRepository;
        public AccountDal(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public int Count(Expression<Func<User, bool>> filter = null)
        {
            return _accountRepository.Count(filter);
        }

        public bool Delete(int id)
        {
            if (_accountRepository.Delete(id))
            {
                return true;
            }

            return false;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _accountRepository.GetAll(filter);
        }

        public User GetById(int id)
        {
            return _accountRepository.GetById(id);
        }

        public bool Insert(User user)
        {
            if (_accountRepository.Insert(user))
                return true;
            else
                return false;
        }

        public bool Update(User user)
        {
            if (_accountRepository.Update(user))
                return true;
            else
                return false;
        }
    }
}
