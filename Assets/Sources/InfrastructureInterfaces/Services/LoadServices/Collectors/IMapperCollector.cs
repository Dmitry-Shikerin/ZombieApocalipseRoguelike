using System;
using Sources.DomainInterfaces.Models.Data;
using Sources.DomainInterfaces.Models.Entities;

namespace Sources.InfrastructureInterfaces.Services.LoadServices.Collectors
{
    public interface IMapperCollector
    {
        Func<IEntity, IDto> GetToDtoMapper(Type type);

        Func<IDto, IEntity> GetToModelMapper(Type type);
    }
}