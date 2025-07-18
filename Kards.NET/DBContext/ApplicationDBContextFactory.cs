using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kards.NET.DBContext;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // IMPORTANT: Use the same connection string your app uses
        optionsBuilder.UseSqlite("Data Source=Kards.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}