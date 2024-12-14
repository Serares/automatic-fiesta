using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics; // use Relational event Id
namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";

        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);

        optionsBuilder.LogTo((message) => Trace.WriteLine(message),
        [RelationalEventId.CommandExecuting])
#if DEBUG
            .EnableSensitiveDataLogging() // include SQL parameters
            .EnableDetailedErrors()
#endif
        ;
        /*
        // Microsoft.EntityFrameworkCore.Proxies
            use this method to Lazy Load db data
            Now, every time the loop enumerates and an attempt is made to read the Products property,
the lazy loading proxy will check if they are loaded. If they’re not loaded, it will load them for
us “lazily” by executing a SELECT statement to load just that set of products for the current
category, and then the correct count will be returned to the output.
        */
        // optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes
        // to limit the length of a category name to 15.
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

        // A global filter to remove discontinued products.
        modelBuilder.Entity<Product>()
        .HasQueryFilter(p => !p.Discontinued);

        // SQLite specific configuration
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // fix lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}