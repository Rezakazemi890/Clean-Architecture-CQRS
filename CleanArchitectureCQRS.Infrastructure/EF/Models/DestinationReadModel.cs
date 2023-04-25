namespace CleanArchitectureCQRS.Infrastructure.EF.Models;

internal class DestinationReadModel
{
    public string City { get; set; }
    public string Country { get; set; }

    public static DestinationReadModel Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new DestinationReadModel
        {
            City = splitLocalization.First(),
            Country = splitLocalization.Last()
        };
    }

    public override string ToString()
        => $"{City},{Country}";
}
