using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Infrastructure.EF.Repositories;

internal sealed class SampleEntityRepository : ISampleEntityRepository
{
    private readonly DbSet<SampleEntity> _sampleEntity;
    private readonly WriteDbContext _writeDbContext;

    public SampleEntityRepository(WriteDbContext writeDbContext)
    {
        _sampleEntity = writeDbContext.SampleEntities;
        _writeDbContext = writeDbContext;
    }

    public Task<SampleEntity> GetAsync(SampleEntityId id)
        => _sampleEntity.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(SampleEntity sampleEntity)
    {
        await _sampleEntity.AddAsync(sampleEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(SampleEntity sampleEntity)
    {
        _sampleEntity.Update(sampleEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(SampleEntity sampleEntity)
    {
        _sampleEntity.Remove(sampleEntity);
        await _writeDbContext.SaveChangesAsync();
    }
}

