using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_PROJE.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Response<NoContext> Add(Product product)
        {
            if (_productDal.Insert(product))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<Product, bool>> filter = null)
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

        public Response<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = _productDal.GetAll(filter);
            if (products != null)
            {
                return Response<List<Product>>.Success(products, 201);
            }
            return Response<List<Product>>.Fail("Veri Bulunamadı!", 404);
        }

        public Response<Product> GetById(int productId)
        {
            Product products = _productDal.GetById(productId);
            if (products != null)
            {
                return Response<Product>.Success(products, 201);
            }
            return Response<Product>.Fail("Kategori Bulunamadı!", 404);
        }


        public Response<NoContext> Update(Product product)
        {
            if (_productDal.Update(product))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
