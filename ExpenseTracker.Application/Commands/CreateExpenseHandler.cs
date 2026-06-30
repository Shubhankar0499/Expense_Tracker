using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Commands.Expenses;


public class CreateExpenseHandler
{
    private readonly IExpenseRepository _repository;


    public CreateExpenseHandler(
        IExpenseRepository repository
    )
    {
        _repository = repository;
    }


    public async Task Handle(CreateExpenseCommand command)
    {
        var expense = new Expense
        {
            Title = command.Title,
            Amount = command.Amount,
            CategoryId = command.CategoryId,
            UserId = command.UserId
        };


        await _repository.AddExpense(expense);
    }
}