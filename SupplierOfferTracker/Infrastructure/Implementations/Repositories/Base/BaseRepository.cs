using Domain.Interfaces;
using Domain.Interfaces.Repositories.Base;
using Infrastructure.Context;

namespace Infrastructure.Implementations.Repositories.Base;

/// <inheritdoc cref="IBaseRepository{TEntity,TKey}"/>
public abstract class BaseRepository<TDbContext, TEntity, TKey>(TDbContext dbContext)
    : ReadonlyRepository<TDbContext, TEntity, TKey>(dbContext), IBaseRepository<TEntity, TKey>
    where TDbContext : LeasingDbContext
    where TEntity : class, IEntity<TKey>
    where TKey : IComparable<TKey>
{
    /// <inheritdoc />
    public virtual TEntity Add(TEntity entity)
    {
        DbSet.Add(entity);

        DbContext.SaveChanges();

        return entity;
    }

    /// <inheritdoc />
    public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);

        DbContext.SaveChanges();

        return entities;
    }

    /// <inheritdoc />
    public virtual TEntity Update(TKey id, TEntity entity)
    {
        entity.Id = id;

        DbSet.Update(entity);

        DbContext.SaveChanges();

        return entity;
    }

    /// <inheritdoc />
    public virtual bool Delete(TEntity entity)
    {
        DbSet.Remove(entity);

        return DbContext.SaveChanges() > 0;
    }

    /// <inheritdoc />
    public virtual bool DeleteRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);

        return DbContext.SaveChanges() > 0;
    }

    /// <inheritdoc />
    public virtual int SaveChanges()
    {
        return DbContext.SaveChanges();
    }

    /// <inheritdoc />
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);

        await DbContext.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity)
    {
        await DbSet.AddRangeAsync(entity);

        await DbContext.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbContext.Update(entity);

        await DbContext.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);

        return await DbContext.SaveChangesAsync() > 0;
    }

    /// <inheritdoc />
    public virtual async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);

        return await DbContext.SaveChangesAsync() > 0;
    }

    /// <inheritdoc />
    public virtual async Task<int> SaveChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
}