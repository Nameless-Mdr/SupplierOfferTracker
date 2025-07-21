using Application.Contracts.Common.Filtering;

namespace Application.Contracts.Common.QueryModels;

/// <summary>
/// Обобщенная модель запроса поиска сущности.
/// </summary>
public abstract class SearchEntityQuery
{
    /// <summary>
    /// Массив фильтров.
    /// </summary>
    // [JsonIgnore]
    // [BindFilterableArray]
    public virtual Filterable[] Filters { get; init; } = [];
}