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
    public class AccountService : IAccountService
    {
        HttpClient _apiClient;
        public AccountService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }

        public Task Add(BasketModel category)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAll(User filter = null)
        {
            var uri = API.AccountApi.GetAccountByUserNameAnadPassword(filter.email, filter.password);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            User basketList = string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<User>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return basketList;
        }

        public Task<int> Count(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(BasketModel category)
        {
            throw new NotImplementedException();
        }
    }
}
