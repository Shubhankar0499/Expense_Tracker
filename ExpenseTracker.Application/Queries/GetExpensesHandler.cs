using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Queries.Expenses;


public class GetExpensesHandler
{
    private readonly IExpenseRepository _repository;


    public GetExpensesHandler(
        IExpenseRepository repository
    )
    {
        _repository = repository;
    }


    public async Task<List<Expense>> Handle(
        GetExpensesQuery query
    )
    {
        var expenses = await _repository.GetExpenses();


        return expenses;
    }
}