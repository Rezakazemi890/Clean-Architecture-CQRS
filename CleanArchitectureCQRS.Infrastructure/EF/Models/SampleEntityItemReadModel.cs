namespace CleanArchitectureCQRS.Infrastructure.EF.Models;

internal class SampleEntityItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsTaken { get; set; }

    public SampleEntityReadModel SampleEntity { get; set; }
}
