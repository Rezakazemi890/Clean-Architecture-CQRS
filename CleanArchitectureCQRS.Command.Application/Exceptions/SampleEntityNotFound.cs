using CleanArchitectureCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchitectureCQRS.Command.Application.Exceptions;

    public class SampleEntityNotFound : PublicException
    {
        public Guid Id { get; }

        public SampleEntityNotFound(Guid id) : base($"sampleEntity with ID '{id}' was not found.")
            => Id = id;
    }
