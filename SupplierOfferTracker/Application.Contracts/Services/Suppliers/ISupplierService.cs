using Application.Contracts.Services.Suppliers.GetPopularSuppliers;

namespace Application.Contracts.Services.Suppliers;

/// <summary>
/// Сервис для работы с поставщиками.
/// </summary>
public interface ISupplierService
{
    /// <summary>
    /// Получение поставщиков с наибольшим количеством офферов.
    /// </summary>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Список популярных поставщиков.</returns>
    Task<IEnumerable<GetPopularSuppliersDto>> GetPopularSuppliersAsync(GetPopularSuppliersQuery query);
}