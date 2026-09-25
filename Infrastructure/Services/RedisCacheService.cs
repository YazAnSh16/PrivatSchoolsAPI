using Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<T?> GetOrSetAsync<T>(
         string key,
         Func<Task<T>> getFunc,
         TimeSpan? expiry = null)
        {
            // Get it from cache
            var cachedData = await _cache.GetStringAsync(key);

            if (cachedData is not null)
            {
                // Cache HIT
                return JsonSerializer.Deserialize<T>(cachedData);
            }

            // 2. Cache MISS Lets do the func
            var data = await getFunc();

            if (data == null)
                return default;

            // 3. fill the cache 
            var json = JsonSerializer.Serialize(data);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(key, json, options);

            return data;
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}

