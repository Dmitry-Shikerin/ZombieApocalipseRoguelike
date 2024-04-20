using System;

namespace Sources.DomainInterfaces.Healths
{
    public interface IHealth
    {
        event Action HealthChanged;
        event Action<float> DamageReceived; 
        
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}