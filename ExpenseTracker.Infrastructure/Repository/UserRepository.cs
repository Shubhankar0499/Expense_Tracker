using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Cache;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;


public class UserRepository : IUserRepository
{

    private readonly ExpenseDbContext _context;
    private readonly RedisCacheService _cache;


    public UserRepository(
        ExpenseDbContext context,
        RedisCacheService cache)
    {
        _context = context;
        _cache = cache;
    }



    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        // clear users list cache if you add one later
    }



    public async Task<User?> GetUser(int id)
    {
        return await GetUserById(id);
    }



    public async Task<User?> GetUserById(int id)
    {

        string key = $"user_{id}";


        // 1. Check Redis first
        var cachedUser =
            await _cache.GetAsync<User>(key);


        if (cachedUser != null)
        {
            Console.WriteLine("🔥 User fetched from Redis");

            return cachedUser;
        }



        Console.WriteLine("🗄️ User fetched from SQL");


        // 2. If not found in Redis, go SQL
        var user =
            await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);



        if (user != null)
        {
            // 3. Save in Redis
            await _cache.SetAsync(
                key,
                user);
        }


        return user;
    }



    public async Task UpdateUser(User user)
    {

        _context.Users.Update(user);

        await _context.SaveChangesAsync();


        // remove old cached data
        await _cache.RemoveAsync(
            $"user_{user.Id}"
        );
    }



    public async Task DeleteUser(User user)
    {

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();


        // remove deleted user from cache
        await _cache.RemoveAsync(
            $"user_{user.Id}"
        );
    }

}