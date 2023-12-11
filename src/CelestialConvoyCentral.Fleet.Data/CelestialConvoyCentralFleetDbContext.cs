using CelestialConvoyCentral.Core;
using CelestialConvoyCentral.Fleet.Domain;
using Microsoft.EntityFrameworkCore;

namespace CelestialConvoyCentral.Fleet.Data;

public class CelestialConvoyCentralFleetDbContext : DbContext, IUnitOfWork
{
    public CelestialConvoyCentralFleetDbContext(DbContextOptions<CelestialConvoyCentralFleetDbContext> options) : base(options) { }

    DbSet<Starship> Starships { get; set; }
    DbSet<Maintenance> Maintenances { get; set; }
    DbSet<MaintenanceItem> MaintenanceItems { get; set; }

    public async Task<bool> Commit()
    {
        foreach(var entry in ChangeTracker.Entries())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
            }
            if(entry.State == EntityState.Modified)
            {
                entry.Property("CreatedAt").IsModified = false;
                entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CelestialConvoyCentralFleetDbContext).Assembly);
    }
}
