using ExpenseTracker.Application.Commands.Expenses;
using ExpenseTracker.Application.Commands.Users;
using ExpenseTracker.Application.Queries.Expenses;
using ExpenseTracker.Application.Queries.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<GetUserHandler>();

        services.AddScoped<UpdateUserHandler>();

        services.AddScoped<DeleteUserHandler>();
        services.AddScoped<CreateUserHandler>();
        services.AddScoped<CreateExpenseHandler>();
        services.AddScoped<GetExpensesHandler>();

        return services;
    }
}