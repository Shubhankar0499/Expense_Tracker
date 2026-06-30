using ExpenseTracker.Application.Clients;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Commands.Expenses;


public class CreateExpenseHandler
{

    private readonly IExpenseRepository _repository;
    private readonly UserClient _userClient;



    public CreateExpenseHandler(
        IExpenseRepository repository,
        UserClient userClient
    )
    {
        _repository = repository;
        _userClient = userClient;
    }



    public async Task Handle(CreateExpenseCommand command)
    {


        // Calling User Service using HttpClient
        var user =
            await _userClient.GetUserById(
                command.UserId
            );



        // If user doesn't exist
        if (user == null)
        {
            throw new Exception(
                "User does not exist"
            );
        }



        var expense = new Expense
        {
            Title = command.Title,

            Amount = command.Amount,

            CategoryId = command.CategoryId,

            // coming from User Service
            UserId = user.Id
        };



        await _repository.AddExpense(expense);

    }

}