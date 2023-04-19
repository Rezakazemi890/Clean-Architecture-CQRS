namespace CleanArchitectureCQRS.Domain.ValueObjects;

    public record SampleEntityDestination(string City, string Country)
    {
        public static SampleEntityDestination Create(string value)
        {
            var splitDestination = value.Split(',');
            return new SampleEntityDestination(splitDestination.First(), splitDestination.Last());
        }

        public override string ToString()
            => $"{City},{Country}";
    }
