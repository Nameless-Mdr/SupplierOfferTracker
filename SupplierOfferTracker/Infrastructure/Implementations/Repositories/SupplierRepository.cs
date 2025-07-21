using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Implementations.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories;

/// <inheritdoc cref="ISupplierRepository"/>
public class SupplierRepository(LeasingDbContext dbContext) : ReadonlyRepository<LeasingDbContext, Supplier, int>(dbContext), ISupplierRepository
{
    private readonly LeasingDbContext _dbContext = dbContext;
    protected override DbSet<Supplier> DbSet => _dbContext.Suppliers;
}