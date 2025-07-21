namespace Application.Contracts.Services.Offers.Add;

/// <summary>
/// Запрос создания оффера.
/// </summary>
public class AddOfferQuery
{
    /// <summary>
    /// Марка.
    /// </summary>
    public string Brand { get; set; }
    
    /// <summary>
    /// Модель.
    /// </summary>
    public string Model { get; set; }
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Поставщик.
    /// </summary>
    public int SupplierId { get; set; }
}