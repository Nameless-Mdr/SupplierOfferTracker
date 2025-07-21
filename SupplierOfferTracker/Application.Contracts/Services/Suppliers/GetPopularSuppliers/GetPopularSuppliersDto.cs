namespace Application.Contracts.Services.Suppliers.GetPopularSuppliers;

/// <summary>
/// Модель популярных поставщиков.
/// </summary>
public record GetPopularSuppliersDto
{
    /// <summary>
    /// Наименование поставщика.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Количество офферов.
    /// </summary>
    public int OffersCount { get; set; }
}