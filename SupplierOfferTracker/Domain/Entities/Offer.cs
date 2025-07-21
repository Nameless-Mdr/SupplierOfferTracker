using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Оффер.
/// </summary>
public class Offer : IEntity<int>
{
    /// <summary>
    /// Идентификатор.
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
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; set; }
    
    /// <summary>
    /// Идентификатор поставщика.
    /// </summary>
    public int SupplierId { get; set; }
    
    /// <summary>
    /// Поставщик.
    /// </summary>
    public Supplier Supplier { get; set; }
}