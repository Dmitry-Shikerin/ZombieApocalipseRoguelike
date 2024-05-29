using System;

namespace Sources.DomainInterfaces.Models.Entities
{
    public interface IEntity
    {
        string Id { get; }

        Type Type { get; }
    }
}