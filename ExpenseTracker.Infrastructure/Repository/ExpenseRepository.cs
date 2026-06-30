using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;


public class ExpenseRepository : IExpenseRepository
{

    private readonly ExpenseDbContext _context;


    public ExpenseRepository(
        ExpenseDbContext context
    )
    {
        _context = context;
    }



    public async Task AddExpense(Expense expense)
    {
        
        
            await _context.Expenses.AddAsync(expense);

            await _context.SaveChangesAsync();
        
        //catch (DbUpdateException)
        //{
        //    throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.");
        //}
    }
    

    public async Task<List<Expense>> GetExpenses()
    {
        return await _context.Expenses.ToListAsync();
    }



    public async Task<Expense?> GetExpenseById(int id)
    {
        return await _context.Expenses
            .FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task DeleteExpense(int id)
    {
        var expense = await GetExpenseById(id);


        if (expense != null)
        {
            _context.Expenses.Remove(expense);

            await _context.SaveChangesAsync();
        }
    }

}