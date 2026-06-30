using ExpenseTracker.Application.Commands.Users;
using ExpenseTracker.Application.Queries.Users;
using ExpenseTracker.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;


namespace ExpenseTracker.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly CreateUserHandler _createHandler;
    private readonly GetUserHandler _getHandler;
    private readonly UpdateUserHandler _updateHandler;
    private readonly DeleteUserHandler _deleteHandler;



    public UserController(
        CreateUserHandler createHandler,
        GetUserHandler getHandler,
        UpdateUserHandler updateHandler,
        DeleteUserHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }



    // CREATE USER
    // POST: api/User
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserCommand command)
    {

        var id = await _createHandler.Handle(command);


        return Ok(new
        {
            UserId = id
        });
    }




    // GET USER BY ID
    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {

        var user = await _getHandler.Handle(id);


        if (user == null)
        {
            return NotFound("User not found");
        }


        return Ok(user);
    }




    // UPDATE USER
    // PUT: api/User
    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateUserCommand command)
    {

        await _updateHandler.Handle(command);


        return Ok("User updated successfully");
    }




    // DELETE USER
    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        await _deleteHandler.Handle(id);


        return Ok("User deleted successfully");
    }

}