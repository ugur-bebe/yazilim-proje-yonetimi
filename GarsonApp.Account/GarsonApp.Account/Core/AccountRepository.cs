using GarsonApp.Account.Abstract;
using GarsonApp.Account.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Account.Core
{
    public class AccountRepository : IAccountRepository
    {
        List<User> categories = new List<User> {
            new User{id = 1, name = "Uğur", surname = "BEBE", email = "ugur.bebe@outlook.com", password = "123", phone_number = "1233", user_name = "ugur.bebe"},

            new User{id = 2, name = "Uğur2", surname = "BEBE2", email = "ugur2.bebe@outlook.com", password = "22123", phone_number = "12332", user_name = "ugur.bebe2"}
        };

        public AccountRepository()
        {
        }

        public int Count(Expression<Func<User, bool>> filter = null)
        {
            return categories.Count;
        }

        public bool Delete(int id)
        {
            var res = categories.Where(x => x.id == id).ToList();
            if (res.Count > 0)
            {
                int index = categories.IndexOf(res[0]);
                if (index == -1) return false;
                categories.RemoveAt(index);
                return true;
            }

            return false;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            if (filter != null)
                return categories.Where(filter.Compile()).ToList();

            return categories;
        }

        public User GetById(int id)
        {
            return categories.Where(x => x.id == id).FirstOrDefault();
        }

        public bool Insert(User entity)
        {
            categories.Add(entity);
            return true;
        }

        public bool Update(User entity)
        {
            var res = categories.Where(x => x.id == entity.id).ToList();
            if (res.Count > 0)
            {
                int index = categories.IndexOf(res[0]);
                if (index == -1) return false;

                categories[index] = entity;
                return true;
            }

            return false;
        }
    }
}
