using ExpenseTracker.Application.Commands.Expenses;
using ExpenseTracker.Application.Commands.Users;
using ExpenseTracker.Application.Clients;
using ExpenseTracker.Application.Queries.Expenses;
using ExpenseTracker.Application.Queries.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {

        // User handlers
        services.AddScoped<GetUserHandler>();

        services.AddScoped<UpdateUserHandler>();

        services.AddScoped<DeleteUserHandler>();

        services.AddScoped<CreateUserHandler>();


        // Expense handlers
        services.AddScoped<CreateExpenseHandler>();

        services.AddScoped<GetExpensesHandler>();



        // Http Client for service-to-service communication
        services.AddHttpClient<UserClient>(client =>
        {
            client.BaseAddress =
                new Uri("https://localhost:7226/");
        });


        return services; 
    }
}