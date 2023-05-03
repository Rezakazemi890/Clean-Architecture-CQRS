using CleanArchitectureCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchitectureCQRS.Query.Application.Exceptions;

    public class SampleEntityNotFound : PublicException
    {
        public Guid Id { get; }

        public SampleEntityNotFound(Guid id) : base($"sampleEntity with ID '{id}' was not found.")
            => Id = id;
    }
