using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_PROJE.Business.Concrete
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryDal _productDal;

        public SubCategoryService(ISubCategoryDal productDal)
        {
            _productDal = productDal;
        }

        public Response<NoContext> Add(SubCategory product)
        {
            if (_productDal.Insert(product))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<SubCategory, bool>> filter = null)
        {
            int count = _productDal.Count();

            if (count >= 0)
            {
                return Response<int>.Success(count, 201);
            }
            return Response<int>.Fail("Hata oluştu!", 200);
        }

        public Response<NoContext> Delete(int id)
        {
            if (_productDal.Delete(id))
            {
                return Response<NoContext>.Success(201);
            }
            return Response<NoContext>.Fail("Kategori bulunamadı", 404);
        }

        public Response<List<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null)
        {
            List<SubCategory> products = _productDal.GetAll(filter);
            if (products != null)
            {
                return Response<List<SubCategory>>.Success(products, 201);
            }
            return Response<List<SubCategory>>.Fail("Veri Bulunamadı!", 404);
        }

        public Response<SubCategory> GetById(int productId)
        {
            SubCategory products = _productDal.GetById(productId);
            if (products != null)
            {
                return Response<SubCategory>.Success(products, 201);
            }
            return Response<SubCategory>.Fail("Kategori Bulunamadı!", 404);
        }


        public Response<NoContext> Update(SubCategory product)
        {
            if (_productDal.Update(product))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
