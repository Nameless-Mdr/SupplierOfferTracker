namespace Domain.Interfaces;

/// <summary>
/// Базовый интерфейс моделей сущностей с обязательным свойством(ами).
/// </summary>
public interface IEntity<TKey>
    where TKey : IComparable<TKey>
{
    TKey Id { get; set; }
}