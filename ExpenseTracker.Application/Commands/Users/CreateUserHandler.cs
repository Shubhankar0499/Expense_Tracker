using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Entities.Users;


namespace ExpenseTracker.Application.Commands.Users;


public class CreateUserHandler
{

    private readonly IUserRepository _repository;


    public CreateUserHandler(
        IUserRepository repository)
    {
        _repository = repository;
    }



    public async Task<int> Handle(CreateUserCommand command)
    {
        var user = new User
        {
            Name = command.Name,
            Email = command.Email
        };


        await _repository.AddUser(user);


        return user.Id;
    }
}