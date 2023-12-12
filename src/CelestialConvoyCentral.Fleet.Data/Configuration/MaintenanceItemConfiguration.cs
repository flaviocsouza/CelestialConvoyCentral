using CelestialConvoyCentral.Fleet.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelestialConvoyCentral.Fleet.Data;

public class MaintenanceItemConfiguration : BaseEntityConfiguration<MaintenanceItem>
{
    public override void Configure(EntityTypeBuilder<MaintenanceItem> builder)
    {
        builder.Property(m => m.ManufacturerId)
        .HasMaxLength(80);
        
        builder.Property(m => m.Model)
        .IsRequired()
        .HasMaxLength(80);
        
        builder.Property(m => m.Description)
        .IsRequired()
        .HasMaxLength(80);
        
        builder.Property(m => m.Price)
        .IsRequired();
        
        base.Configure(builder);
    }

}
