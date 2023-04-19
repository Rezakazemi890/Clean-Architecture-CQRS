using CleanArchitectureCQRS.Domain.Exceptions;

namespace CleanArchitectureCQRS.Domain.ValueObjects;

    public record SampleEntityItem
    {
        public string Name { get; }
        public uint Quantity { get; }

        public bool IsTaken { get; init; }

        public SampleEntityItem(string name, uint quantity, bool isTaken = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new SampleInvalidException();
            }

            Name = name;
            Quantity = quantity;
            IsTaken = isTaken;
        }
    }
