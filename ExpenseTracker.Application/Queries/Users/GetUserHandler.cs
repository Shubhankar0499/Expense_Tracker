using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Queries.Users;


public class GetUserHandler
{

    private readonly IUserRepository _repository;


    public GetUserHandler(
        IUserRepository repository)
    {
        _repository = repository;
    }


    public async Task<User?> Handle(int id)
    {
        return await _repository.GetUserById(id);
    }
}