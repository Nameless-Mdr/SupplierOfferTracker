using Application.Contracts.Services.Offers;
using Application.Contracts.Services.Offers.Add;
using Application.Contracts.Services.Offers.Common;
using Application.Contracts.Services.Offers.SearchOffers;
using Domain.Entities;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

/// <summary>
/// Контроллер для работы с <see cref="Offer"/>.
/// </summary>
[ApiController]
[Route("[controller]")]
public class OffersController : BaseController
{
    private readonly IOfferService _offerService;

    public OffersController(IOfferService offerService)
    {
        _offerService = offerService;
    }

    /// <summary>
    /// Создание оффера.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /Offers/Add
    ///     {
    ///         "Brand": "string",
    ///         "Model": "string",
    ///         "RegistrationDate": "2025-07-21T00:00:00Z",
    ///         "SupplierId": int
    ///     }
    /// </remarks>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Идентификатор созданного оффера.</returns>
    [HttpPost("[action]")]
    public async Task<int> Add([FromBody] AddOfferQuery query)
    {
        return await _offerService.AddOfferAsync(query);
    }

    /// <summary>
    /// Поиск офферов.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     GET /Offers/Search?filters[0].Property=Brand&amp;filters[0].Operator=Contains&amp;filters[0].Value=auid
    ///     &amp;filters[1].Property=supplier&amp;filters[1].Operator=Contains&amp;filters[1].Value=A
    ///     &amp;filters[2].Property=model&amp;filters[2].Operator=Contains&amp;filters[2].Value=r8
    /// </remarks>
    /// <param name="query">Параметры запроса.</param>
    /// <returns>Коллекция найденных офферов.</returns>
    [HttpGet("[action]")]
    public async Task<SearchOffersDto> Search([FromQuery] SearchOffersQuery query)
    {
        return await _offerService.SearchOfferAsync(query);
    }
}