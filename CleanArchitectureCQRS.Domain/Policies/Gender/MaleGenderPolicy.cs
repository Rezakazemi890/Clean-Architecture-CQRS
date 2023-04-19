using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Policies.Gender;

    internal sealed class MaleGenderPolicy : ISampleEntityItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;

        public IEnumerable<SampleEntityItem> GenerateItems(PolicyData data)
            => new List<SampleEntityItem>
            {
                new("Male1", 1),
                new("Male2", 1),
                new("Male3", 1)
            };
    }
