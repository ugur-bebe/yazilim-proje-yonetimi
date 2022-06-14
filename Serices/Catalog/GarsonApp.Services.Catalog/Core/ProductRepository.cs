using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Core
{
    public class ProductRepository : IProductRepository
    {
        List<Product> categories = new List<Product> {
            new Product
            {
                id = 1,
                name = "Product 1",
                restourantId = 1,
                description = "Açıklama 1",
                imageId = "imageId_1",
                price = 25,
                title = "Title 1"
            },
            new Product
            {
                id = 2,
                name = "Product 2",
                restourantId = 1,
                description = "Açıklama 2",
                imageId = "imageId_2",
                price = 250,
                title = "Title 2"
            },
            new Product
            {
                id = 3,
                name = "Product 3",
                restourantId = 2,
                description = "Açıklama 3",
                imageId = "imageId_3",
                price = 20,
                title = "Title 3"
            },
            new Product
            {
                id = 4,
                name = "Product 4",
                restourantId = 2,
                description = "Açıklama 4",
                imageId = "imageId_4",
                price = 20,
                title = "Title 4"
            },
            new Product
            {
                id = 5,
                name = "Product 5",
                restourantId = 3,
                description = "Açıklama 5",
                imageId = "imageId_5",
                price = 30,
                title = "Title 5"
            },
            new Product
            {
                id = 6,
                name = "Product 6",
                restourantId = 3,
                description = "Açıklama 6",
                imageId = "imageId_6",
                price = 40,
                title = "Title 6"
            }
        };

        public ProductRepository()
        {
        }

        public int Count(Expression<Func<Product, bool>> filter = null)
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

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return categories.Where(filter.Compile()).ToList();
        }

        public Product GetById(int id)
        {
            return categories.Where(x => x.id == id).FirstOrDefault();
        }

        public bool Insert(Product entity)
        {
            categories.Add(entity);
            return true;
        }

        public bool Update(Product entity)
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
