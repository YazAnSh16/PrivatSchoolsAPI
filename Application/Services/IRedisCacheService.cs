using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRedisCacheService
    {
        Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> getFunc, TimeSpan? expiry = null);
        Task RemoveAsync(string key);
    }
}
