using CleanArchitectureCQRS.Application.Services;
using CleanArchitectureCQRS.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Infrastructure.EF.Services;

internal sealed class SampleEntityReadService : ISampleEntityReadService
{
    private readonly DbSet<SampleEntityReadModel> _sampleEntity;

    public SampleEntityReadService(ReadDbContext context)
        => _sampleEntity = context.SampleEntities;

    public Task<bool> ExistsByNameAsync(string name)
        => _sampleEntity.AnyAsync(pl => pl.Name == name);
}
