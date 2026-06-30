using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Interfaces;


public interface IUserRepository
{
    Task AddUser(User user);

    Task<User?> GetUserById(int id);

    Task UpdateUser(User user);

    Task DeleteUser(User user);
}