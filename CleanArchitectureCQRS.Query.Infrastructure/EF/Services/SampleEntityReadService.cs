using CleanArchitectureCQRS.Shared.Services;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF.Services;

internal sealed class SampleEntityReadService : ISampleEntityReadService
{
    private readonly DbSet<SampleEntityReadModel> _sampleEntity;

    public SampleEntityReadService(ReadDbContext context)
        => _sampleEntity = context.SampleEntities;

    public Task<bool> ExistsByNameAsync(string name)
        => _sampleEntity.AnyAsync(pl => pl.Name == name);
}
