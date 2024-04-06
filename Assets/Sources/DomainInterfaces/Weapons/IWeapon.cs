using System;
using System.Threading;

namespace Sources.DomainInterfaces.Weapons
{
    public interface IWeapon
    {
        event Action Attacked;
        
        float Damage { get; }
        float AttackSpeed { get; }
        bool IsReady { get; }

        void AttackAsync(CancellationToken cancellationToken);
    }
}