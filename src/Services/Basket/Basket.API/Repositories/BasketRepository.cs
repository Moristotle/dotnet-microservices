using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redis;

        public BasketRepository(IDistributedCache redis)
        {
            _redis = redis;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redis.RemoveAsync(userName);
        }


        [return: NotNullIfNotNull("userName")]
        public async Task<ShoppingCart?> GetBasket(string userName)
        {
            var basket = await _redis.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket)!;


        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            await _redis.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }
    }
}