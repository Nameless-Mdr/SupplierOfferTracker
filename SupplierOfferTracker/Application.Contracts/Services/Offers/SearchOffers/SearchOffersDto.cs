using Application.Contracts.Services.Offers.Common;

namespace Application.Contracts.Services.Offers.SearchOffers;

/// <summary>
/// Модель найденных офферов.
/// </summary>
public record SearchOffersDto
{
    /// <summary>
    /// Количество найденных офферов.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Коллекция найденных офферов.
    /// </summary>
    public IEnumerable<GetOffersDto> Offers { get; set; }
}