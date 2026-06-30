using ExpenseTracker.Application.Interfaces;


namespace ExpenseTracker.Application.Commands.Users;


public class UpdateUserHandler
{

    private readonly IUserRepository _repository;


    public UpdateUserHandler(
        IUserRepository repository)
    {
        _repository = repository;
    }



    public async Task Handle(UpdateUserCommand command)
    {

        var user = await _repository
            .GetUserById(command.Id);


        if (user == null)
            return;


        user.Name = command.Name;
        user.Email = command.Email;


        await _repository.UpdateUser(user);

    }
}