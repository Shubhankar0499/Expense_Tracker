using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace ExpenseTracker.Infrastructure.Cache;


public class RedisCacheService
{

    private readonly IDistributedCache _cache;


    public RedisCacheService(
        IDistributedCache cache)
    {
        _cache = cache;
    }



    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiry = null)
    {

        var json =
            JsonSerializer.Serialize(value);


        await _cache.SetStringAsync(
            key,
            json,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    expiry ?? TimeSpan.FromMinutes(10)
            });

    }



    public async Task<T?> GetAsync<T>(
        string key)
    {

        var data =
            await _cache.GetStringAsync(key);


        if (data == null)
        {
            Console.WriteLine("Redis MISS");
            return default;
        }


        Console.WriteLine("Redis HIT");


        return JsonSerializer.Deserialize<T>(data);
    }



    public async Task RemoveAsync(
        string key)
    {
        await _cache.RemoveAsync(key);
    }

}