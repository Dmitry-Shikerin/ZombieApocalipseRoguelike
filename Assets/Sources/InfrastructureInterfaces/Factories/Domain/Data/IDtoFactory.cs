using Sources.DomainInterfaces.Data;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IDtoFactory<T>
        where T : IDto
    {
        T Create(IDataModel dataModel);
    }
}