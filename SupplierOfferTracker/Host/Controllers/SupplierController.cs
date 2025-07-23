using Application.Contracts.Services.Suppliers;
using Application.Contracts.Services.Suppliers.GetPopularSuppliers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

/// <summary>
/// Контроллер для работы с <see cref="Supplier"/>.
/// </summary>
[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    /// <summary>
    /// Получение поставщиков с наибольшим количеством офферов.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     GET /Supplier/GetPopularSuppliers?Top=3
    /// </remarks>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Список популярных поставщиков.</returns>
    [HttpGet("[action]")]
    public async Task<IEnumerable<GetPopularSuppliersDto>> GetPopularSuppliers([FromQuery] GetPopularSuppliersQuery query)
    {
        return await _supplierService.GetPopularSuppliersAsync(query);
    }
}