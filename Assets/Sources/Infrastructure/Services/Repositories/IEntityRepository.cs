using System.Collections.Generic;
using Sources.DomainInterfaces.Entities;

namespace Sources.Infrastructure.Services.Repositories
{
    public interface IEntityRepository
    {
        IReadOnlyDictionary<string, IEntity> Entities { get; }
        
        void Add(IEntity entity);
        IEntity Get(string id);
        void Release();
    }
}