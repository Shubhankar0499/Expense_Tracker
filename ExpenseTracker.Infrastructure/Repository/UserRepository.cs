using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;


public class UserRepository : IUserRepository
{

    private readonly ExpenseDbContext _context;


    public UserRepository(
        ExpenseDbContext context)
    {
        _context = context;
    }



    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }



    public async Task<User?> GetUser(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync();
    }



    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}