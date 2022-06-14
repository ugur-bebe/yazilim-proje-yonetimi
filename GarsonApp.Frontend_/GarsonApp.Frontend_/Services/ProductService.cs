using GarsonApp.Frontend.Infrastructure;
using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _apiClient;
        public ProductService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }

        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll(int restourantId)
        {
            var uri = API.ProductApi.GetAllProducts(restourantId);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<List<Product>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Product> GetById(int id)
        {
            var uri = API.ProductApi.GetProductById(id);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<Product>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
