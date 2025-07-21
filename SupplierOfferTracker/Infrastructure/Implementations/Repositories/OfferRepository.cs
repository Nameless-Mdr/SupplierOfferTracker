using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Implementations.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories;

/// <inheritdoc cref="IOfferRepository"/>
public class OfferRepository(LeasingDbContext dbContext) : BaseRepository<LeasingDbContext, Offer, int>(dbContext), IOfferRepository
{
    private readonly LeasingDbContext _dbContext = dbContext;
    protected override DbSet<Offer> DbSet => _dbContext.Offers;
}