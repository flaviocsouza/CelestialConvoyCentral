namespace CelestialConvoyCentral.Core;

public interface IUnitOfWork
{
        Task<bool> Commit();
}
