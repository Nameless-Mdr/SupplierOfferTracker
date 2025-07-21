namespace Application.Contracts.Services.Offers.Common;

/// <summary>
/// Модель получения коллекции офферов.
/// </summary>
public record GetOffersDto
{
    /// <summary>
    /// Идентификатор оффера.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Марка.
    /// </summary>
    public string Brand { get; set; }
    
    /// <summary>
    /// Модель.
    /// </summary>
    public string Model { get; set; }
    
    /// <summary>
    /// Поставщик.
    /// </summary>
    public string Supplier { get; set; }
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; set; }
}