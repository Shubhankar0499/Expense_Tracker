using ExpenseTracker.Application.Interfaces;


namespace ExpenseTracker.Application.Commands.Users;


public class DeleteUserHandler
{

    private readonly IUserRepository _repository;


    public DeleteUserHandler(
        IUserRepository repository)
    {
        _repository = repository;
    }



    public async Task Handle(int id)
    {

        var user = await _repository.GetUserById(id);


        if (user == null)
            return;


        await _repository.DeleteUser(user);
    }
}