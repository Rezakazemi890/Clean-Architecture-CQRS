using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureCQRS.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<SampleEntity>, IEntityTypeConfiguration<SampleEntityItem>
{
    public void Configure(EntityTypeBuilder<SampleEntity> builder)
    {
        builder.HasKey(pl => pl.Id);

        var destinationConverter = new ValueConverter<SampleEntityDestination, string>(l => l.ToString(),
            l => SampleEntityDestination.Create(l));

        var packingListNameConverter = new ValueConverter<SampleEntityName, string>(pln => pln.Value,
            pln => new SampleEntityName(pln));

        builder
            .Property(pl => pl.Id)
            .HasConversion(id => id.Value, id => new SampleEntityId(id));

        builder
            .Property(typeof(SampleEntityDestination), "_destination")
            .HasConversion(destinationConverter)
            .HasColumnName("Destination");

        builder
            .Property(typeof(SampleEntityName), "_name")
            .HasConversion(packingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(typeof(SampleEntityItem), "_items");

        builder.ToTable("SampleEntity");
    }

    public void Configure(EntityTypeBuilder<SampleEntityItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(pi => pi.Name);
        builder.Property(pi => pi.Quantity);
        builder.Property(pi => pi.IsTaken);
        builder.ToTable("SampleEntityItems");
    }
}
