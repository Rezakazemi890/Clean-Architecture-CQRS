using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Policies.Gender;

    internal sealed class FemaleGenderPolicy : ISampleEntityItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Female;

        public IEnumerable<SampleEntityItem> GenerateItems(PolicyData data)
            => new List<SampleEntityItem>
            {
                new("Female1", 1),
                new("Female2", 1),
                new("Female3", 1)
            };
    }
