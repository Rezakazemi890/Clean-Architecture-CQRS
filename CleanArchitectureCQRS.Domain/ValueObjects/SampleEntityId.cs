using CleanArchitectureCQRS.Domain.Exceptions;

namespace CleanArchitectureCQRS.Domain.ValueObjects;

    public record SampleEntityId
    {
        public Guid Value { get; }

        public SampleEntityId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new SampleInvalidException();
            }

            Value = value;
        }

        public static implicit operator Guid(SampleEntityId id)
          => id.Value;

        public static implicit operator SampleEntityId(Guid id)
            => new(id);

    }
