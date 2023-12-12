namespace CelestialConvoyCentral.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork _unitOfWork { get; }
}