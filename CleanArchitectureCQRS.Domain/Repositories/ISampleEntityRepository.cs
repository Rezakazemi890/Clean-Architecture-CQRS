using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Repositories;

    public interface ISampleEntityRepository
    {
        Task<IQueryable<SampleEntity>> GetAsync();
        Task<SampleEntity> GetAsyncById(SampleEntityId id);
        Task AddAsync(SampleEntity sampleEntity);
        Task UpdateAsync(SampleEntity sampleEntity);
        Task DeleteAsync(SampleEntity sampleEntity);
    }
