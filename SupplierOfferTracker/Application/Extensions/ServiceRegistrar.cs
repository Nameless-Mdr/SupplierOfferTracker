using Application.Contracts.Services.Offers;
using Application.Contracts.Services.Suppliers;
using Application.Services.Offers;
using Application.Services.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

/// <summary>
/// Регистрация методов сервисов.
/// </summary>
public static class ServiceRegistrar
{
    /// <summary>
    /// Регистрация сервисов
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <returns>Коллекция сервисов</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<ISupplierService, SupplierService>();

        return services;
    }
}