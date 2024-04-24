using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Data;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IDtoMapper<out T, in T1>
        where T : IDto
        where T1 : IEntity
    {
        T MapTo(T1 dataModel);
    }
}