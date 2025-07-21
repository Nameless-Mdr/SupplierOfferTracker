using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class LeasingDbContext : DbContext
{
    /// <summary>
    /// Инициализация экземпляра класса <see cref="LeasingDbContext"/>
    /// </summary>
    /// <param name="options">Опции контекста базы данных.</param>
    public LeasingDbContext(DbContextOptions<LeasingDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}