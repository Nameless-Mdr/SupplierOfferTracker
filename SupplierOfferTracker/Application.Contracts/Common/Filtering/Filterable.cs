namespace Application.Contracts.Common.Filtering;

/// <summary>
/// Параметры фильтрации.
/// </summary>
public class Filterable
{
    /// <summary>
    /// Фильтруемое свойство.
    /// </summary>
    public string Property { get; init; }

    /// <summary>
    /// Оператор фильтрации.
    /// </summary>
    public FilterOperator Operator { get; init; }

    /// <summary>
    /// Значение фильтрации.
    /// </summary>
    public string Value { get; init; }
}