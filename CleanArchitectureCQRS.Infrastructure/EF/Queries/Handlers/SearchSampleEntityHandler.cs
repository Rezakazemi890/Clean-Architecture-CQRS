using CleanArchitectureCQRS.Application.DTOs;
using CleanArchitectureCQRS.Application.Queries;
using CleanArchitectureCQRS.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Infrastructure.EF.Models;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchSampleEntityHandler : IQueryHandler<SearchSampleEntity, IEnumerable<SampleEntityDto>>
{
    private readonly DbSet<SampleEntityReadModel> _SampleEntities;

    public SearchSampleEntityHandler(ReadDbContext context)
        => _SampleEntities = context.SampleEntities;

    public async Task<IEnumerable<SampleEntityDto>> HandleAsync(SearchSampleEntity query)
    {
        var dbQuery = _SampleEntities
            .Include(pl => pl.Items)
        .AsQueryable();

        if (query.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(pl =>
                Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}

