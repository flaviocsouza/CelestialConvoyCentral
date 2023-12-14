namespace CelestialConvoyCentral.Fleet.Domain;

public interface IStarshipManufacturerClient
{
    public Task<StarshipModel> GetModelByClientID(int id);
}
