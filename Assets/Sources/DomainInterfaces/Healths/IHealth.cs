using System;

namespace Sources.DomainInterfaces.Healths
{
    public interface IHealth
    {
        event Action HealthChanged;
        
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}