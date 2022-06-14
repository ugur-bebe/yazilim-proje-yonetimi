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
    public class RestourantService : IRestourantService
    {
        private readonly HttpClient _apiClient;
        public RestourantService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }
        public async Task<List<Restourant>> GetAll(int take, Restourant filter = null)
        {
            var uri = API.RestourantApi.GetAllRestourant(take, filter);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<List<Restourant>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task Add(Restourant category)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(Expression<Func<Restourant, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Restourant> GetById(int id)
        {
            var uri = API.CategoryApi.GetAllCategoryes();
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<Restourant>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task Update(Restourant category)
        {
            throw new NotImplementedException();
        }
    }
}
