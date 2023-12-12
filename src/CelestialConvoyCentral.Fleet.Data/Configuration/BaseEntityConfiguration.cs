using CelestialConvoyCentral.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelestialConvoyCentral.Fleet.Data;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        
        builder.HasKey(t => t.Id);

        builder.Property(t => t.CreatedAt)
        .IsRequired();

        builder.Property(t => t.UpdatedAt)
        .IsRequired();
        
        builder.Ignore(t => t.Active);
    }
}
