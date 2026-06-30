using ExpenseTracker.Application.Commands.Expenses;
using ExpenseTracker.Application.Queries.Expenses;
using Microsoft.AspNetCore.Mvc;


namespace ExpenseTracker.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{

    private readonly CreateExpenseHandler _createHandler;
    private readonly GetExpensesHandler _getHandler;



    public ExpenseController(
        CreateExpenseHandler createHandler,
        GetExpensesHandler getHandler
    )
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }



    [HttpPost]
    public async Task<IActionResult> Create(
       [FromBody] CreateExpenseCommand command
    )
    {

        await _createHandler.Handle(command);


        return Ok("Expense Created");
    }



    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var expenses = await _getHandler.Handle(
            new GetExpensesQuery()
        );


        return Ok(expenses);
    }

}