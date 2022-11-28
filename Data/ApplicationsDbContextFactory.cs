using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Module4HW4.Data;

public class ApplicationsDbContextFactory : IDesignTimeDbContextFactory<ApplicationsDbContext>
{
    public ApplicationsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationsDbContext>();
        var connectionString = new ConfigurationBuilder().AddJsonFile("config.json").Build()
            .GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(
            connectionString,
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

        return new ApplicationsDbContext(optionsBuilder.Options);
    }
}