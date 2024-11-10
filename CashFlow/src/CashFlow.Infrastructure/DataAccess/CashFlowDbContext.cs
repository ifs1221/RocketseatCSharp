using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Port=3306;Database=cashflow;Uid=root;Pwd=@Teste123";
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
        optionsBuilder.UseMySql(connectionString, serverVersion);
        base.OnConfiguring(optionsBuilder);
    }
}
