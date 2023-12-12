namespace CelestialConvoyCentral.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
