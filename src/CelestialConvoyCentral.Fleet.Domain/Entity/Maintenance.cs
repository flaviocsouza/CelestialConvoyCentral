using CelestialConvoyCentral.Core;

namespace CelestialConvoyCentral.Fleet.Domain;

public class Maintenance : Entity
{
    public Guid StarshipId { get; private set; }
    public decimal EstimateBudget { get; private set; }
    public DateTime EstimatedCompletionDate { get; private set; }
    public decimal? Budget { get; private set; } 
    public DateTime? CompletionDate { get; private set; }
    public List<MaintenanceItem> Items { get; }

    public Starship Starship { get; private set;}

    public Maintenance(Guid starshipId, decimal estimateBudget, DateTime estimatedCompletionDate, decimal? budget = null, DateTime? completionDate = null)
    {
        StarshipId = starshipId;
        EstimateBudget = estimateBudget;
        EstimatedCompletionDate = estimatedCompletionDate;
        Budget = budget;
        CompletionDate = completionDate;
        Items = new List<MaintenanceItem>();
    }

    public void FinishMaintenance()
    {
        CompletionDate = DateTime.Now;        
        Budget = GetCurrentBudget();
    }

    public void AddMaintenanceItem(MaintenanceItem item)
    {
        Items.Add(item);
    }

    public void RemoveMaintenanceItem(MaintenanceItem item)
    {
        Items.Remove(item);
    }

    public decimal GetCurrentBudget()
    {
        decimal currentbudget = 0;
        foreach(var item in Items)
            currentbudget += item.Price;

        return currentbudget;
    }
}
