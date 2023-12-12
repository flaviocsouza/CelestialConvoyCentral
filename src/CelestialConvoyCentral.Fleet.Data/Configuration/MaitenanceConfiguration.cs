using CelestialConvoyCentral.Fleet.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelestialConvoyCentral.Fleet.Data;

public class MaitenanceConfiguration : BaseEntityConfiguration<Maintenance>
{
    public override void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.Property(m => m.EstimateBudget)
        .IsRequired();
        
        builder.Property(m => m.EstimatedCompletionDate)
        .IsRequired();

        builder.HasMany(m => m.Items)
        .WithOne(i => i.Maintenance)
        .HasForeignKey(i => i.MaintenanceId); 

        base.Configure(builder);
    }

}
