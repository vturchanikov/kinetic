using FleetService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetService.Infrastructure.Persistence.Configurations;

public class BusConfiguration : IEntityTypeConfiguration<Bus>
{
    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Code)
            .IsRequired()
            .HasMaxLength(5);

        builder.HasIndex(b => b.Code)
            .IsUnique();

        builder.Property(b => b.Model)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Capacity)
            .IsRequired();

        builder.HasMany(b => b.Seats)
            .WithOne(s => s.Bus)
            .HasForeignKey(s => s.BusId);

        builder.Navigation(b => b.Seats)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
