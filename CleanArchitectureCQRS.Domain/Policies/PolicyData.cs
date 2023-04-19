using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Policies;

    public record PolicyData(Consts.Gender Gender, SampleEntityDestination Destination);
