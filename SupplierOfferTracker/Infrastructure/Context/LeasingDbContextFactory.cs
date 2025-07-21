using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context;

public class LeasingDbContextFactory : IDesignTimeDbContextFactory<LeasingDbContext>
{
    public LeasingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LeasingDbContext>();

        optionsBuilder.UseSqlServer("LeasingDataConnectionString", b =>
        {
            b.MigrationsAssembly(typeof(LeasingDbContext).Assembly.FullName);
        });
        
        return new LeasingDbContext(optionsBuilder.Options);
    }
}