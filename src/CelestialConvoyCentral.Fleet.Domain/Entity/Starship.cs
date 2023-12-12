using CelestialConvoyCentral.Core;

namespace CelestialConvoyCentral.Fleet.Domain;

public class Starship : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public int Crew { get; private set; }
    public decimal PropellantCapacity { get; private set; }
    public decimal Propellant { get; private set; }
    public bool IsUnderMaintenance  { get; private set; }
    public bool IsDestroyedInCombat { get; private set; }

    public Guid MaintenanceId { get; private set;}

    public List<Maintenance> MaintenanceHistory { get; private set;}
    public Maintenance? Maintenance { get; private set;}

    public Starship(string name, string model, string manufacturer, int crew, bool isUnderMaintenance = false, bool isDestroyedInCombat = false)
    {
        Name = name;
        Model = model;
        Manufacturer = manufacturer;
        Crew = crew;
        IsUnderMaintenance = isUnderMaintenance;
        IsDestroyedInCombat = isDestroyedInCombat;
        MaintenanceHistory = new List<Maintenance>();
    }

    public decimal GetRemainingFuel() =>  Propellant/PropellantCapacity;

    public void SendToMaintenance(Maintenance maintenance)
    {
        IsUnderMaintenance = true;
        Maintenance = maintenance;
    }

    public void ReturnFromMaintenance()
    {
        IsUnderMaintenance = false;
        Maintenance?.FinishMaintenance();
    }

    public void DestroyedInCombat()
    {
        IsDestroyedInCombat = true;
    }

    public void Refuel(decimal amount = 0)
    {
        if(amount < 0) return;
        if(amount == 0) Propellant = PropellantCapacity;
        
        //Ideia: Quando os comandos tiverem impelementados,
        //emitir um comando (warning) quando issso acontecer
        var newPropellantAmout = amount + Propellant;
        Propellant = newPropellantAmout < PropellantCapacity 
            ? newPropellantAmout 
            : PropellantCapacity;
    }

}
