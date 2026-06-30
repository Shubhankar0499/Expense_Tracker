using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Data;


public class ExpenseDbContext : DbContext
{
    public ExpenseDbContext(
        DbContextOptions<ExpenseDbContext> options
    ) : base(options)
    {

    }


    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>()
            .Property(x => x.Amount)
            .HasPrecision(18, 2);
    }
}