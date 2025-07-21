namespace Domain.Interfaces.Repositories.Base;

/// <summary>
/// Интерфейс с операциями чтениями сущностей.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TKey">Тип первичного ключа сущности.</typeparam>
public interface IReadonlyRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : IComparable<TKey>
{
    /// <summary>
    /// Получение коллекции сущностей.
    /// </summary>
    /// <returns>Коллекция сущностей базы данных.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Получение записи сущности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Модель сущности.</returns>
    TEntity GetById(TKey id);

    /// <summary>
    /// Получение записи сущности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Модель сущности.</returns>
    Task<TEntity> GetByIdAsync(TKey id);
}