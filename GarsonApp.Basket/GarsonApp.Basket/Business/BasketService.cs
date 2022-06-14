using GarsonApp.Basket.Abstract;
using GarsonApp.Basket.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Business
{
    public class BasketService : IBasketService
    {
        IBasketDal _basketDal;
        public BasketService(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }
        public Response<List<BasketModel>> GetAll(Expression<Func<BasketModel, bool>> filter = null)
        {
            List<BasketModel> basketModels = _basketDal.GetAll(filter);
            if (basketModels != null)
            {
                return Response<List<BasketModel>>.Success(basketModels, 201);
            }
            return Response<List<BasketModel>>.Fail("Veri Bulunamadı!", 404);
        }
        public Response<NoContext> Add(BasketModel product)
        {
            if (_basketDal.Insert(product))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<BasketModel, bool>> filter = null)
        {
            int count = _basketDal.Count();

            if (count >= 0)
            {
                return Response<int>.Success(count, 201);
            }
            return Response<int>.Fail("Hata oluştu!", 200);
        }

        public Response<NoContext> Delete(int id)
        {
            if (_basketDal.Delete(id))
            {
                return Response<NoContext>.Success(201);
            }
            return Response<NoContext>.Fail("Kategori bulunamadı", 404);
        }

        public Response<BasketModel> GetById(int basketId)
        {
            BasketModel products = _basketDal.GetById(basketId);
            if (products != null)
            {
                return Response<BasketModel>.Success(products, 201);
            }
            return Response<BasketModel>.Fail("Kategori Bulunamadı!", 404);
        }


        public Response<NoContext> Update(BasketModel basketModel)
        {
            if (_basketDal.Update(basketModel))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
