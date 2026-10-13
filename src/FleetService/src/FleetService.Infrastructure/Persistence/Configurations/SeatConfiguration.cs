using FleetService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetService.Infrastructure.Persistence.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Number)
            .IsRequired();

        builder.Property(s => s.Status)
            .IsRequired();

        builder.HasIndex(s => new { s.BusId, s.Number })
            .IsUnique();
    }
}
