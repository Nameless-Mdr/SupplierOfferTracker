using Application.Contracts.Services.Offers.Add;
using Application.Contracts.Services.Offers.SearchOffers;

namespace Application.Contracts.Services.Offers;

/// <summary>
/// Сервис для работы с офферами.
/// </summary>
public interface IOfferService
{
    /// <summary>
    /// Создание оффера.
    /// </summary>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Идентификатор созданного оффера.</returns>
    Task<int> AddOfferAsync(AddOfferQuery query);

    /// <summary>
    /// Поиск офферов.
    /// </summary>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Коллекция найденных офферов.</returns>
    Task<SearchOffersDto> SearchOfferAsync(SearchOffersQuery query);
}