using GarsonApp.Account.Abstract;
using GarsonApp.Account.Concrete;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Account.Business
{
    public class AccountService : IAccountService
    {
        IAccountDal _accountDal;
        public AccountService(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public Response<NoContext> Add(User user)
        {
            if (_accountDal.Insert(user))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<User, bool>> filter = null)
        {
            int count = _accountDal.Count();

            if (count >= 0)
            {
                return Response<int>.Success(count, 201);
            }
            return Response<int>.Fail("Hata oluştu!", 200);
        }

        public Response<NoContext> Delete(int id)
        {
            if (_accountDal.Delete(id))
            {
                return Response<NoContext>.Success(201);
            }
            return Response<NoContext>.Fail("Kullanıcı bulunamadı", 404);
        }

        public Response<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            List<User> userList = _accountDal.GetAll(filter);
            if (userList != null)
            {
                return Response<List<User>>.Success(userList, 201);
            }
            return Response<List<User>>.Fail("Veri Bulunamadı!", 404);
        }

        public Response<User> GetById(int id)
        {
            User user = _accountDal.GetById(id);
            if (user != null)
            {
                return Response<User>.Success(user, 201);
            }
            return Response<User>.Fail("Kategori Bulunamadı!", 404);
        }

        public Response<NoContext> Update(User user)
        {
            if (_accountDal.Update(user))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
