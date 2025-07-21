namespace Application.Contracts.Common.Filtering;

/// <summary>
/// Перечисление функций фильтраций.
/// </summary>
public enum FilterOperator
{
    /// <summary>
    /// Равно.
    /// </summary>
    Equals,

    /// <summary>
    /// Не равно.
    /// </summary>
    NotEquals,

    /// <summary>
    /// Строго больше.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Строго меньше.
    /// </summary>
    LessThan,

    /// <summary>
    /// Больше или равно.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Меньше или равно.
    /// </summary>
    LessThanOrEqual,

    /// <summary>
    /// Содержит подстроку.
    /// </summary>
    Contains,

    /// <summary>
    /// Начинается с подстроки.
    /// </summary>
    StartsWith,

    /// <summary>
    /// Заканчивается подстрокой.
    /// </summary>
    EndsWith
}