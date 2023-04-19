using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Policies;

    public interface ISampleEntityItemsPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<SampleEntityItem> GenerateItems(PolicyData data);
    }
