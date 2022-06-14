using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Core
{
    public class CategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category> {
            new Category() { Id = "1", Name = "Ev Yemekleri" },
            new Category() { Id = "2", Name = "Fast food" },
            new Category() { Id = "3", Name = "İçecek" },
            new Category() { Id = "4", Name = "Pasta & Tatlılar" },
            new Category() { Id = "5", Name = "Dünya Mutfağı" },
            new Category() { Id = "6", Name = "Yöresel" }
        };

        public CategoryRepository()
        {
            
        }

        public int Count(Expression<Func<Category, bool>> filter = null)
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

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return categories;
        }

        public Category GetById(int id)
        {
            return categories.Where(x => x.Id == id.ToString()).FirstOrDefault();
        }

        public bool Insert(Category entity)
        {
            categories.Add(entity);
            return true;
        }

        public bool Update(Category entity)
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
