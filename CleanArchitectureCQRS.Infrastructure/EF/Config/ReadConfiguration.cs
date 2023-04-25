using CleanArchitectureCQRS.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureCQRS.Infrastructure.EF.Config;

    internal sealed class ReadConfiguration : IEntityTypeConfiguration<SampleEntityReadModel>, IEntityTypeConfiguration<SampleEntityItemReadModel>
    {
        public void Configure(EntityTypeBuilder<SampleEntityReadModel> builder)
        {
            builder.ToTable("SampleEntity");
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.Destination)
                .HasConversion(l => l.ToString(), l => DestinationReadModel.Create(l));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.SampleEntity);
        }

        public void Configure(EntityTypeBuilder<SampleEntityItemReadModel> builder)
        {
            builder.ToTable("SampleEntityItems");
        }
    }
