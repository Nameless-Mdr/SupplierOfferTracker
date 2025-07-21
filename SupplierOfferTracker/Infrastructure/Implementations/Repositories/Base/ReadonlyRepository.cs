using Domain.Interfaces;
using Domain.Interfaces.Repositories.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories.Base;

/// <inheritdoc />
public abstract class ReadonlyRepository<TDbContext, TEntity, TKey>(TDbContext dbContext)
    : IReadonlyRepository<TEntity, TKey>
    where TDbContext : LeasingDbContext
    where TEntity : class, IEntity<TKey>
    where TKey : IComparable<TKey>
{
    protected readonly TDbContext DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    protected abstract DbSet<TEntity> DbSet { get; }

    /// <inheritdoc />
    public virtual IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    /// <inheritdoc />
    public virtual TEntity GetById(TKey id)
    {
        var entity = DbSet.FirstOrDefault(x => x.Id.CompareTo(id) == 0);

        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<TEntity> GetByIdAsync(TKey id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.Id.CompareTo(id) == 0);

        return entity;
    }
}