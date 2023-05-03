using CleanArchitectureCQRS.Query.Application.DTOs;
using CleanArchitectureCQRS.Query.Application.Queries;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Models;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF.Queries.Handlers;

internal sealed class GetSampleEntityHandler : IQueryHandler<GetSampleEntity, SampleEntityDto>
{
    private readonly DbSet<SampleEntityReadModel> _SampleEntities;

    public GetSampleEntityHandler(ReadDbContext context)
        => _SampleEntities = context.SampleEntities;

    public Task<SampleEntityDto> HandleAsync(GetSampleEntity query)
        => _SampleEntities
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}
