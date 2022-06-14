using GarsonApp.Business.Concrete;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Response<NoContext> Add(Category category)
        {
            if (_categoryDal.Insert(category))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kullanıcı Adı Daha Önce Kullanılmış!", 200);
        }

        public Response<int> Count(Expression<Func<Category, bool>> filter = null)
        {
            int count = _categoryDal.Count();

            if (count >= 0)
            {
                return Response<int>.Success(count, 201);
            }
            return Response<int>.Fail("Hata oluştu!", 200);
        }

        public Response<NoContext> Delete(int id)
        {
            if (_categoryDal.Delete(id))
            {
                return Response<NoContext>.Success(201);
            }
            return Response<NoContext>.Fail("Kategori bulunamadı", 404);
        }

        public Response<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            List<Category> categories = _categoryDal.GetAll();
            if (categories != null)
            {
                return Response<List<Category>>.Success(categories, 201);
            }
            return Response<List<Category>>.Fail("Veri Bulunamadı!", 404);
        }

        public Response<Category> GetById(int categoryId)
        {
            Category categories = _categoryDal.GetById(categoryId);
            if (categories != null)
            {
                return Response<Category>.Success(categories, 201);
            }
            return Response<Category>.Fail("Kategori Bulunamadı!", 404);
        }


        public Response<NoContext> Update(Category category)
        {
            if (_categoryDal.Update(category))
            {
                return Response<NoContext>.Success(201);
            }

            return Response<NoContext>.Fail("Kategori bulunamadı!", 404);
        }
    }
}
