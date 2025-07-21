using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

/// <summary>
/// Регистрация контекста и репозиториев.
/// </summary>
public static class DbContextRegistrar
{
    /// <summary>
    /// Регистрация контекста базы данных.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LeasingDataConnectionString");

        return services.AddDbContext<LeasingDbContext>(opts =>
        {
            opts.UseSqlServer(connectionString, builder =>
            {
                builder.CommandTimeout(1200);
                builder.MigrationsAssembly(typeof(LeasingDbContext).Assembly.FullName);
            });
        })
        .AddRepositories();
    }
    
    /// <summary>
    /// Регистрация репозиториев.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов.</returns>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        
        return services;
    }
    
    /// <summary>
    /// Выполнение миграций.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static async Task ApplyMigrations(this IServiceCollection services)
    {
        await using var scope = services.BuildServiceProvider().CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetService<LeasingDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}