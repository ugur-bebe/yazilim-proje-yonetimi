using GarsonApp.Services.Catalog.Abstract.Dal;
using GarsonApp.Services.Catalog.Abstract.Services;
using GarsonApp.Services.Catalog.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Business
{
    public class RestourantService : IRestourantService
    {
        private readonly IRestourantDal _restourantDal;

        public RestourantService(IRestourantDal restourantDal)
        {
            _restourantDal = restourantDal;
        }

        public Response<NoContext> Add(Restaurant restourant)
        {
            if (_restourantDal.Insert(restourant))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<Restaurant, bool>> filter = null)
        {
            int count = _restourantDal.Count();

            if (count >= 0)
            {
                return Response<int>.Success(count, 201);
            }
            return Response<int>.Fail("Hata oluştu!", 200);
        }

        public Response<NoContext> Delete(int id)
        {
            if (_restourantDal.Delete(id))
            {
                return Response<NoContext>.Success(201);
            }
            return Response<NoContext>.Fail("Kategori bulunamadı", 404);
        }

        public Response<List<Restaurant>> GetAll(int take, Expression<Func<Restaurant, bool>> filter = null)
        {
            List<Restaurant> restourant = _restourantDal.GetAll(take, filter);
            if (restourant != null)
            {
                return Response<List<Restaurant>>.Success(restourant, 201);
            }
            return Response<List<Restaurant>>.Fail("Veri Bulunamadı!", 404);
        }

        public Response<Restaurant> GetById(int productId)
        {
            Restaurant restourant = _restourantDal.GetById(productId);
            if (restourant != null)
            {
                return Response<Restaurant>.Success(restourant, 201);
            }
            return Response<Restaurant>.Fail("Kategori Bulunamadı!", 404);
        }


        public Response<NoContext> Update(Restaurant restourant)
        {
            if (_restourantDal.Update(restourant))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
