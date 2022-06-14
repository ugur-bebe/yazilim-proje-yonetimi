using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Core
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        List<SubCategory> categories = new List<SubCategory> {
            new SubCategory() { Id = "1", Name = "Börek" , CategoryId = 1 },
            new SubCategory() { Id = "2", Name = "Mantı" , CategoryId = 1 },
            new SubCategory() { Id = "3", Name = "Ekler" , CategoryId = 2 },
            new SubCategory() { Id = "4", Name = "Yaş Pasta" , CategoryId = 2 },
            new SubCategory() { Id = "5", Name = "Yöresel" , CategoryId = 3 },
            new SubCategory() { Id = "6", Name = "Yöresel" , CategoryId = 3 },
        };
        public SubCategoryRepository()
        {

        }

        public int Count(Expression<Func<SubCategory, bool>> filter = null)
        {
            return categories.Count;
        }

        public bool Delete(int id)
        {
            var res = categories.Where(x => x.Id == id.ToString()).ToList();
            if (res.Count > 0)
            {
                int index = categories.IndexOf(res[0]);
                if (index == -1) return false;
                categories.RemoveAt(index);
                return true;
            }

            return false;
        }

        public List<SubCategory> GetAll(Expression<Func<SubCategory, bool>> filter = null)
        {
            return categories;
        }

        public SubCategory GetById(int id)
        {
            return categories.Where(x => x.Id == id.ToString()).FirstOrDefault();
        }

        public bool Insert(SubCategory entity)
        {
            categories.Add(entity);
            return true;
        }

        public bool Update(SubCategory entity)
        {
            var res = categories.Where(x => x.Id == entity.Id.ToString()).ToList();
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
