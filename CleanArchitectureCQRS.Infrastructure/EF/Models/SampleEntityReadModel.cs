namespace CleanArchitectureCQRS.Infrastructure.EF.Models;

internal class SampleEntityReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public DestinationReadModel Destination { get; set; }
    public ICollection<SampleEntityItemReadModel> Items { get; set; }
}
