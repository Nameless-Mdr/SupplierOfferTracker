namespace Domain.Interfaces.Repositories.Base;

/// <summary>
/// Базовый интерфейс с основными CRUD-операциями.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TKey">Тип первичного ключа сущности.</typeparam>
public interface IBaseRepository<TEntity, TKey> : IReadonlyRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : IComparable<TKey>
{
    /// <summary>
    /// Метод создания записи.
    /// </summary>
    /// <param name="entity">Модель создаваемой сущности.</param>
    /// <returns>Созданная сущность.</returns>
    TEntity Add(TEntity entity);

    /// <summary>
    /// Метод добавления коллекции сущностей.
    /// </summary>
    /// <param name="entities">Коллекция создаваемых сущностей.</param>
    /// <returns>Коллекция созданных сущностей.</returns>
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Метод обновления сущности.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <param name="entity">Обновленная модель сущности.</param>
    /// <returns>Обновленная модель сущности.</returns>
    TEntity Update(TKey id, TEntity entity);

    /// <summary>
    /// Метод удаления записи.
    /// </summary>
    /// <param name="entity">Модель удаляемой сущности.</param>
    /// <returns>Результат выполнения удаления.</returns>
    bool Delete(TEntity entity);

    /// <summary>
    /// Метод удаления коллекции записей.
    /// </summary>
    /// <param name="entities">Коллекция удаляемых сущностей.</param>
    /// <returns>Результат выполнения удаления.</returns>
    bool DeleteRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Метод сохранения контекста.
    /// </summary>
    /// <returns>Количество затронутых строк.</returns>
    int SaveChanges();

    /// <summary>
    /// Асинхронный метод создания записи.
    /// </summary>
    /// <param name="entity">Модель создаваемой сущности.</param>
    /// <returns>Созданная сущность.</returns>
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// Асинхронный метод добавления коллекции сущностей.
    /// </summary>
    /// <param name="entities">Коллекция создаваемых сущностей.</param>
    /// <returns>Коллекция созданных сущностей.</returns>
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Асинхронный метод обновления сущности.
    /// </summary>
    /// <param name="entity">Обновленная модель сущности.</param>
    /// <returns>Обновленная модель сущности.</returns>
    Task<TEntity> UpdateAsync(TEntity entity);

    /// <summary>
    /// Асинхронный метод удаления записи.
    /// </summary>
    /// <param name="entity">Модель удаляемой сущности.</param>
    /// <returns>Результат выполнения удаления.</returns>
    Task<bool> DeleteAsync(TEntity entity);

    /// <summary>
    /// Асинхронный метод удаления коллекции записей.
    /// </summary>
    /// <param name="entities">Коллекция удаляемых сущностей.</param>
    /// <returns>Результат выполнения удаления.</returns>
    Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Асинхронный метод сохранения контекста.
    /// </summary>
    /// <returns>Количество затронутых строк.</returns>
    Task<int> SaveChangesAsync();
}