using CleanArchitectureCQRS.Domain.Exceptions;

namespace CleanArchitectureCQRS.Domain.ValueObjects;

    public record SampleEntityName
    {
        public string Value { get; }

        public SampleEntityName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new SampleInvalidException();
            }

            Value = value.Trim();
        }


        public static implicit operator string(SampleEntityName name)
            => name.Value;

        public static implicit operator SampleEntityName(string name)
            => new(name);
    }
