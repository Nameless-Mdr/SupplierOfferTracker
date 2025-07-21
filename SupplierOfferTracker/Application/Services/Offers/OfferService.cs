using Application.Common.Extensions.Filtering;
using Application.Contracts.Services.Offers;
using Application.Contracts.Services.Offers.Add;
using Application.Contracts.Services.Offers.Common;
using Application.Contracts.Services.Offers.SearchOffers;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Offers;

/// <inheritdoc />
public class OfferService : IOfferService
{
    private readonly IOfferRepository _offerRepository;

    public OfferService(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    /// <inheritdoc />
    public async Task<int> AddOfferAsync(AddOfferQuery query)
    {
        var offer = new Offer
        {
            Brand = query.Brand,
            Model = query.Model,
            RegistrationDate = query.RegistrationDate,
            SupplierId = query.SupplierId,
        };
        await _offerRepository.AddAsync(offer);
        
        return offer.Id;
    }

    /// <inheritdoc />
    public async Task<SearchOffersDto> SearchOfferAsync(SearchOffersQuery query)
    {
        var searchedOffers = _offerRepository.GetAll()
            .Select(x => new GetOffersDto
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                RegistrationDate = x.RegistrationDate,
                Supplier = x.Supplier.Name,
            })
            .ApplyFilter(query.Filters);

        var data = new SearchOffersDto
        {
            Count = await searchedOffers.CountAsync(),
            Offers = await searchedOffers.ToArrayAsync(),
        };
        
        return data;
    }
}