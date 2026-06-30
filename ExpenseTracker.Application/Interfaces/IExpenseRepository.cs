using ExpenseTracker.Domain.Entities;


namespace ExpenseTracker.Application.Interfaces;


public interface IExpenseRepository
{
    Task AddExpense(Expense expense);

    Task<List<Expense>> GetExpenses();

    Task<Expense?> GetExpenseById(int id);

    Task DeleteExpense(int id);
}