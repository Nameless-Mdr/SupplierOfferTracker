using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Application.Contracts.Common.Filtering;
using Application.Contracts.Exceptions;
using static Application.Constants.Delimiters;

namespace Application.Common.Extensions.Filtering;

/// <summary>
/// Методы расширения <see cref="IQueryable" /> связанные с фильтрацией.
/// </summary>
public static class FilteringExtensions
{
    /// <summary>
    /// Применение набора фильтров к источнику данных <see cref="IQueryable{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="source">Источник данных.</param>
    /// <param name="filterables">Коллекция фильтров.</param>
    /// <returns>Отфильтрованный <see cref="IQueryable{TEntity}" />.</returns>
    public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> source, IEnumerable<Filterable> filterables)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (filterables == null || !filterables.Any())
        {
            return source;
        }

        var parameterExpression = Expression.Parameter(typeof(TEntity), "x");
        Expression finalExpression = null;

        var groupedFilters = filterables.GroupBy(f => new { f.Property, f.Operator });

        foreach (var filterGroup in groupedFilters)
        {
            Expression groupExpression = null;

            foreach (var filter in filterGroup)
            {
                if (!IsPropertyExists<TEntity>(filter.Property))
                {
                    throw new InvalidFilterException(typeof(TEntity), filter.Property);
                }

                var comparisonExpression = BuildComparisonExpression(parameterExpression, filter);

                groupExpression = groupExpression == null
                    ? comparisonExpression
                    : Expression.OrElse(groupExpression, comparisonExpression);
            }

            finalExpression = finalExpression == null
                ? groupExpression
                : Expression.AndAlso(finalExpression, groupExpression!);
        }

        if (finalExpression == null)
        {
            return source;
        }

        var lambda = Expression.Lambda<Func<TEntity, bool>>(finalExpression, parameterExpression);
        return source.Where(lambda);
    }

    /// <summary>
    /// Построение выражения для сравнения свойства с заданным значением фильтра.
    /// </summary>
    /// <param name="parameterExpression">Параметр выражения.</param>
    /// <param name="filter">Фильтр с параметрами сравнения.</param>
    /// <returns>Выражение для фильтрации данных.</returns>
    private static Expression BuildComparisonExpression(ParameterExpression parameterExpression, Filterable filter)
    {
        var propertyPath = filter.Property.Split(UrlKeyDelimiter);
        var expression = BuildPropertyExpression(parameterExpression, propertyPath, filter);
        return expression;
    }

    /// <summary>
    /// Построение выражения для доступа к свойству, включая вложенные свойства.
    /// </summary>
    /// <param name="parameterExpression">Параметр выражения.</param>
    /// <param name="propertyPath">Путь к свойству.</param>
    /// <param name="filter">Фильтр с параметрами сравнения.</param>
    /// <returns>Выражение для доступа к свойству.</returns>
    private static Expression BuildPropertyExpression(Expression parameterExpression, string[] propertyPath, Filterable filter)
    {
        var currentExpression = parameterExpression;

        for (var i = 0; i < propertyPath.Length; i++)
        {
            var propertyName = propertyPath[i];
            currentExpression = Expression.PropertyOrField(currentExpression, propertyName);

            if (typeof(IEnumerable).IsAssignableFrom(currentExpression.Type) && currentExpression.Type != typeof(string) &&
                i < propertyPath.Length - 1)
            {
                var elementType = currentExpression.Type.GetGenericArguments().First();
                var lambdaParam = Expression.Parameter(elementType, "x");

                var innerExpression = BuildPropertyExpression(lambdaParam, propertyPath.Skip(i + 1).ToArray(), filter);

                var anyLambda = Expression.Lambda(innerExpression, lambdaParam);

                return BuildEnumerableExpression(currentExpression, elementType, anyLambda, "Any");
            }
        }

        return BuildFilterExpression(currentExpression, filter);
    }

    /// <summary>
    /// Создание выражения для фильтрации значения свойства в зависимости от оператора фильтра.
    /// </summary>
    /// <param name="propertyExpression">Выражение свойства.</param>
    /// <param name="filter">Фильтр с параметрами сравнения.</param>
    /// <returns>Выражение для выполнения фильтрации.</returns>
    private static Expression BuildFilterExpression(Expression propertyExpression, Filterable filter)
    {
        var propertyType = propertyExpression.Type;

        ValidateFilterValue(filter, propertyType);

        var constantExpression = Expression.Constant(ConvertToPropertyType(propertyType, filter.Value), propertyType);

        ValidateFilterOperator(filter, propertyType);

        return filter.Operator switch
        {
            FilterOperator.Equals => Expression.Equal(propertyExpression, constantExpression),
            FilterOperator.NotEquals => Expression.NotEqual(propertyExpression, constantExpression),
            FilterOperator.GreaterThan => Expression.GreaterThan(propertyExpression, constantExpression),
            FilterOperator.LessThan => Expression.LessThan(propertyExpression, constantExpression),
            FilterOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(propertyExpression, constantExpression),
            FilterOperator.LessThanOrEqual => Expression.LessThanOrEqual(propertyExpression, constantExpression),
            FilterOperator.Contains => BuildStringExpression(propertyExpression, "Contains", filter.Value),
            FilterOperator.StartsWith => BuildStringExpression(propertyExpression, "StartsWith", filter.Value),
            FilterOperator.EndsWith => BuildStringExpression(propertyExpression, "EndsWith", filter.Value),
            _ => throw new InvalidFilterException(filter.Operator, filter.Property)
        };
    }

    /// <summary>
    /// Проверка допустимости оператора фильтра для заданного типа свойства.
    /// </summary>
    /// <param name="filter">Фильтр с параметрами сравнения.</param>
    /// <param name="propertyType">Тип свойства.</param>
    private static void ValidateFilterOperator(Filterable filter, Type propertyType)
    {
        var notNullableProperty = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        switch (filter.Operator)
        {
            case FilterOperator.Equals:
            case FilterOperator.NotEquals:
                break;

            case FilterOperator.GreaterThan:
            case FilterOperator.LessThan:
            case FilterOperator.GreaterThanOrEqual:
            case FilterOperator.LessThanOrEqual:
                if (!IsComparableType(notNullableProperty))
                {
                    throw new InvalidFilterException(filter.Operator, filter.Property);
                }

                break;

            case FilterOperator.Contains:
            case FilterOperator.StartsWith:
            case FilterOperator.EndsWith:
                if (notNullableProperty != typeof(string))
                {
                    throw new InvalidFilterException(filter.Operator, filter.Property);
                }

                break;

            default:
                throw new InvalidFilterException(filter.Operator, filter.Property);
        }
    }

    /// <summary>
    /// Проверка допустимости значения фильтра для заданного типа свойства.
    /// </summary>
    /// <param name="filter">Фильтр с параметрами сравнения.</param>
    /// <param name="propertyType">Тип свойства.</param>
    /// <returns><c>true</c>, если значение допустимо, иначе <c>false</c>.</returns>
    private static void ValidateFilterValue(Filterable filter, Type propertyType)
    {
        if (filter.Value == null)
        {
            if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                return;
            }
        }

        var underlyingType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        if (!underlyingType.IsInstanceOfType(filter.Value))
        {
            try
            {
                _ = Convert.ChangeType(filter.Value, underlyingType);
            }
            catch (Exception)
            {
                throw new InvalidFilterException(filter.Value, filter.Property, propertyType.Name);
            }
        }
    }

    /// <summary>
    /// Проверка, является ли тип сравнимым для операций сравнения.
    /// </summary>
    /// <param name="type">Тип для проверки.</param>
    /// <returns><c>true</c>, если тип поддерживает сравнение, иначе <c>false</c>.</returns>
    private static bool IsComparableType(Type type)
    {
        return type == typeof(byte) ||
               type == typeof(sbyte) ||
               type == typeof(short) ||
               type == typeof(ushort) ||
               type == typeof(int) ||
               type == typeof(uint) ||
               type == typeof(long) ||
               type == typeof(ulong) ||
               type == typeof(float) ||
               type == typeof(double) ||
               type == typeof(decimal) ||
               type == typeof(DateTime) ||
               type == typeof(TimeSpan) ||
               type == typeof(char);
    }

    /// <summary>
    /// Создание выражения для выполнения строковой операции (например, Contains, StartsWith, EndsWith).
    /// </summary>
    /// <param name="propertyExpression">Выражение свойства строки.</param>
    /// <param name="function">Название метода строки.</param>
    /// <param name="value">Значение для сравнения.</param>
    /// <returns>Выражение для выполнения строковой операции.</returns>
    private static Expression BuildStringExpression(Expression propertyExpression, string function, object value)
    {
        var method = typeof(string).GetMethod(function, new[] { typeof(string) });
        return Expression.Call(propertyExpression, method!, Expression.Constant(value, typeof(string)));
    }

    /// <summary>
    /// Создание выражения для работы с коллекциями, например с методом Any.
    /// </summary>
    /// <param name="propertyExpression">Выражение коллекции.</param>
    /// <param name="elementType">Тип элемента в коллекции.</param>
    /// <param name="lambda">Выражение условия для элементов.</param>
    /// <param name="function">Название метода коллекции (например, Any).</param>
    /// <returns>Выражение для фильтрации элементов коллекции.</returns>
    private static Expression BuildEnumerableExpression(Expression propertyExpression, Type elementType, LambdaExpression lambda,
        string function)
    {
        var method = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .First(m => m.Name == function && m.GetParameters().Length == 2)
            .MakeGenericMethod(elementType);

        return Expression.Call(null, method, propertyExpression, lambda);
    }

    /// <summary>
    /// Проверяка наличия свойства в типе сущности.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="propertyName">Имя свойства.</param>
    /// <returns><c>true</c>, если свойство существует, иначе <c>false</c>.</returns>
    private static bool IsPropertyExists<TEntity>(string propertyName)
    {
        var propertyPath = propertyName.Split(UrlKeyDelimiter);
        var type = typeof(TEntity);

        foreach (var property in propertyPath)
        {
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                type = type.GetGenericArguments().First();
            }

            var propertyInfo = type.GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                return false;
            }

            type = propertyInfo.PropertyType;
        }

        return true;
    }

    /// <summary>
    /// Конвертация значения фильтра в соответствующий тип свойства.
    /// </summary>
    /// <param name="propertyType">Тип свойства.</param>
    /// <param name="value">Значение для конвертации.</param>
    /// <returns>Сконвертированное значение.</returns>
    private static object ConvertToPropertyType(Type propertyType, object value)
    {
        if (value == null)
        {
            return null;
        }

        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            propertyType = Nullable.GetUnderlyingType(propertyType)!;
        }

        return Convert.ChangeType(value, propertyType);
    }
}