namespace ExpenseTracker.Application.Commands.Expenses;


public class CreateExpenseCommand
{
    public string Title { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }
}