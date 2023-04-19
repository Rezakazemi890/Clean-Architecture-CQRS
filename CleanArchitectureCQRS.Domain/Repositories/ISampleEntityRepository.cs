using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Repositories;

    public interface ISampleEntityRepository
    {
        Task<SampleEntity> GetAsync(SampleEntityId id);
        Task AddAsync(SampleEntity sampleEntity);
        Task UpdateAsync(SampleEntity sampleEntity);
        Task DeleteAsync(SampleEntity sampleEntity);
    }
