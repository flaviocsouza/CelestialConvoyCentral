using System.Security.Cryptography.X509Certificates;
using CelestialConvoyCentral.Fleet.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelestialConvoyCentral.Fleet.Data;

public class StarshipConfiguration : BaseEntityConfiguration<Starship>
{
    public override void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.Property(s => s.Name)
        .IsRequired()
        .HasMaxLength(80);

        builder.Property(s => s.Model)
        .IsRequired()
        .HasMaxLength(80);
        
        builder.Property(s => s.Manufacturer)
        .IsRequired()
        .HasMaxLength(80);

        builder.Property(s => s.Crew)
        .IsRequired();

        builder.Property(s => s.PropellantCapacity)
        .IsRequired();

        builder.Property(s => s.Propellant)
        .IsRequired();

        builder.Property(s => s.IsDestroyedInCombat)
        .IsRequired();

        builder.Property(s => s.IsDestroyedInCombat)
        .IsRequired();

        builder.HasMany(s => s.MaintenanceHistory)
        .WithOne(m => m.Starship)
        .HasForeignKey(m => m.StarshipId);

        builder.HasOne(s => s.Maintenance)
        .WithOne(m => m.Starship)
        .HasForeignKey<Starship>(s => s.MaintenanceId)
        .HasForeignKey<Maintenance>(m => m.StarshipId);

        base.Configure(builder);

    }

}
