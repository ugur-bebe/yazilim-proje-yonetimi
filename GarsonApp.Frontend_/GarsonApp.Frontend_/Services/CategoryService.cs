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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _apiClient;
        public CategoryService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var uri = API.CategoryApi.GetAllCategoryes();
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<List<Category>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task Add(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
