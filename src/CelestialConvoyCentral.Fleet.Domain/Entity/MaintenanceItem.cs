using CelestialConvoyCentral.Core;

namespace CelestialConvoyCentral.Fleet.Domain;

public class MaintenanceItem : Entity
{
    public string? ManufacturerId { get; private set;}
    public string Model { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public MaintenanceItem(string model, decimal price, string description, string? manufacturerId = null)
    {
        Price = price;
        Model = model;
        Description = description;
        ManufacturerId = manufacturerId;
    }
}
