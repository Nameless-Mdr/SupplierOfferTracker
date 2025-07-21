using Application.Contracts.Common.Filtering;

namespace Application.Contracts.Exceptions;

/// <summary>
/// Исключение при ошибке в операции фильтрации.
/// </summary>
public class InvalidFilterException : Exception
{
    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" />.
    /// </summary>
    public InvalidFilterException()
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" />.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public InvalidFilterException(string message) : base(message)
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" /> в случае ошибки не найденного свойства в сущности.
    /// </summary>
    /// <param name="entity">Имя сущности.</param>
    /// <param name="property">Имя свойства.</param>
    public InvalidFilterException(Type entity, string property)
        : base($"Сущность {entity.Name} не содержит свойства '{property}'")
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" /> в случае ошибки оператора.
    /// </summary>
    /// <param name="operation">Оператор фильтрации.</param>
    /// <param name="property">Имя свойства.</param>
    public InvalidFilterException(FilterOperator operation, string property)
        : base($"Оператор фильтрации '{operation}' не поддерживается для свойства '{property}'")
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" /> в случае ошибки несоответствия типа значения и свойства.
    /// </summary>
    /// <param name="value">Значение фильтрации.</param>
    /// <param name="property">Имя свойства.</param>
    /// <param name="propertyType">Тип свойства.</param>
    public InvalidFilterException(object value, string property, string propertyType)
        : base($"Невозможно применить значение '{value}' для свойства '{property}' типа '{propertyType}'")
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="InvalidFilterException" />.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public InvalidFilterException(string message, Exception innerException) : base(message, innerException)
    {
    }
}