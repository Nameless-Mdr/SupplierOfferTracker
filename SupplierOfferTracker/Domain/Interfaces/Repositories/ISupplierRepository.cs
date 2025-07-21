using Domain.Entities;
using Domain.Interfaces.Repositories.Base;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Репозиторий для работы с сущностью БД <see cref="Supplier"/>.
/// </summary>
public interface ISupplierRepository : IReadonlyRepository<Supplier, int>
{
    
}