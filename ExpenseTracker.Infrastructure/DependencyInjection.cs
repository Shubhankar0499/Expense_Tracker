using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseTracker.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        return services;
    }
}