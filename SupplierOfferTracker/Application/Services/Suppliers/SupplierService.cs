using Application.Contracts.Services.Suppliers;
using Application.Contracts.Services.Suppliers.GetPopularSuppliers;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Suppliers;

/// <inheritdoc />
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<GetPopularSuppliersDto>> GetPopularSuppliersAsync(GetPopularSuppliersQuery query)
    {
        return await _supplierRepository.GetAll()
            .Select(x => new GetPopularSuppliersDto
            {
                Name = x.Name,
                OffersCount = x.Offers.Count,
            })
            .OrderByDescending(x => x.OffersCount)
            .Take(query.Top)
            .ToArrayAsync();
    }
}