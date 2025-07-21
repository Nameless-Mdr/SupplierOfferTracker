namespace Application.Contracts.Services.Suppliers.GetPopularSuppliers;

/// <summary>
/// Модель запроса популярных поставщиков.
/// </summary>
public class GetPopularSuppliersQuery
{
    /// <summary>
    /// Количество запрашиваемых поставщиков.
    /// </summary>
    public int Top { get; set; } = 3;
}