using System;

namespace Sources.DomainInterfaces.FirstActions
{
    public interface IFirstActionModel
    {
        event Action FirstActionActivate;
        
        string Id { get; }
    }
}