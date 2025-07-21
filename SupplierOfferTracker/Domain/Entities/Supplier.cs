using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Поставщик.
/// </summary>
public class Supplier : IEntity<int>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Коллекция офферов.
    /// </summary>
    public ICollection<Offer> Offers { get; set; }
}