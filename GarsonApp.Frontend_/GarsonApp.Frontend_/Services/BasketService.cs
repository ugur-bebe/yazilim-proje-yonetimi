using GarsonApp.Frontend.Infrastructure;
using GarsonApp.Frontend.Models;
using GarsonApp.Frontend.Models.Dtos;
using GarsonApp.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _apiClient;
        private readonly IProductService _productService;
        public BasketService(HttpClient httpClient, IProductService productService)
        {
            _apiClient = httpClient;
            _productService = productService;
        }
        public async Task<List<BasketDto>> GetAll(int userId)
        {
            var uri = API.BasketApi.GetAllBasket(userId);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            List<BasketModel> basketList = string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<List<BasketModel>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            List<BasketDto> basketDtoList = new List<BasketDto>();

            foreach (BasketModel item in basketList)
            {
                Product p = _productService.GetById(item.productId).Result;
                basketDtoList.Add(new BasketDto
                {
                    id = item.id,
                    ownerId = item.ownerId,
                    productId = item.productId,
                    piece = item.piece,
                    product = p
                });
            }

            return basketDtoList;
        }

        public async Task Add(BasketModel basketModel)
        {
            var uri = API.BasketApi.InsertBasket();
            var response = await _apiClient.PostAsync(uri, new StringContent(JsonSerializer.Serialize(basketModel), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public Task<int> Count(Expression<Func<BasketModel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var uri = API.BasketApi.DeleteBasketItem(id);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async Task<BasketModel> GetById(int id)
        {
            var uri = API.CategoryApi.GetAllCategoryes();
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ? null :
            JsonSerializer.Deserialize<BasketModel>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task Update(BasketModel category)
        {
            throw new NotImplementedException();
        }
    }
}
