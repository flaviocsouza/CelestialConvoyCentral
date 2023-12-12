using CelestialConvoyCentral.Core.Data;
using CelestialConvoyCentral.Fleet.Domain;

namespace CelestialConvoyCentral.Fleet.Data;

public class StarshipRepository : IStarshipRepository
{
    private readonly CelestialConvoyCentralFleetDbContext _context;
    public IUnitOfWork _unitOfWork => _context;

    public StarshipRepository(CelestialConvoyCentralFleetDbContext context)
    {
        _context = context;
    }


    public void Dispose()
    {
        _context?.Dispose();
    }
}
